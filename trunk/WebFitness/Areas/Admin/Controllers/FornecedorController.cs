using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFitness.classes;

namespace WebFitness.Areas.Admin.Controllers
{
    public class FornecedorController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Fornecedor";

        //
        // GET: /Admin/Fornecedor/

        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var fornecedor = db.Fornecedor.Include(f => f.Cidade);
            return View(fornecedor.ToList());
        }

        //
        // GET: /Admin/Fornecedor/Details/5

        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        //
        // GET: /Admin/Fornecedor/Create

        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade");
            return View();
        }

        //
        // POST: /Admin/Fornecedor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fornecedor fornecedor)
        {
            @ViewBag.Controller = controller;
            fornecedor.dtCriacao = DateTime.Now;
            fornecedor.status = (byte) Status.Ativo;
            fornecedor.idFornecedor = 1;
            fornecedor.dsFornecedor = Validation.SyntaxName(fornecedor.dsFornecedor);

            if (ModelState.IsValid)
            {
                db.Fornecedor.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", fornecedor.idCidade);
            return View(fornecedor);
        }

        //
        // GET: /Admin/Fornecedor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", fornecedor.idCidade);
            return View(fornecedor);
        }

        //
        // POST: /Admin/Fornecedor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fornecedor fornecedor)
        {
            @ViewBag.Controller = controller;
            fornecedor.dsFornecedor = Validation.SyntaxName(fornecedor.dsFornecedor);
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", fornecedor.idCidade);
            return View(fornecedor);
        }

        //
        // GET: /Admin/Aluno/Inactive/5

        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;
            Fornecedor fornecedor = db.Fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            fornecedor.status = (byte)Status.Inativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Aluno/Active/5

        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;
            Fornecedor fornecedor = db.Fornecedor.Find(id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            fornecedor.status = (byte)Status.Ativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public bool CheckCnpj(string cnpj){


            try
            {

      

                Fornecedor fornecedor = (from u 
                                         in db.Fornecedor
                                         where u.cnpj == cnpj
                                        select u).First();

                return true;
            }
            catch {
                return false;
            }

            
        }
    }
}