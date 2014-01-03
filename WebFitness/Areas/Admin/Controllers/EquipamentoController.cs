using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFitness.Classes;

namespace WebFitness.Areas.Admin.Controllers
{
    public class EquipamentoController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Equipamento";
        //
        // GET: /Admin/Equipamento/
        [Authorize]
        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var equipamento = db.Equipamento.Include(e => e.Fornecedor);
            return View(equipamento.ToList());
        }

        //
        // GET: /Admin/Equipamento/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Equipamento equipamento = db.Equipamento.Find(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }
            return View(equipamento);
        }

        //
        // GET: /Admin/Equipamento/Create
        [Authorize]
        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "dsFornecedor");
            return View();
        }

        //
        // POST: /Admin/Equipamento/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipamento equipamento)
        {
            @ViewBag.Controller = controller;
            equipamento.dtCriacao = DateTime.Now;
            equipamento.status_ = (byte) Status.Ativo;
            equipamento.idEquipamento = 1;

            if (ModelState.IsValid)
            {
                db.Equipamento.Add(equipamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "dsFornecedor", equipamento.idFornecedor);
            return View(equipamento);
        }

        //
        // GET: /Admin/Equipamento/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Equipamento equipamento = db.Equipamento.Find(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "dsFornecedor", equipamento.idFornecedor);
            return View(equipamento);
        }

        //
        // POST: /Admin/Equipamento/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipamento equipamento)
        {
            @ViewBag.Controller = controller;
            if (ModelState.IsValid)
            {
                db.Entry(equipamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "dsFornecedor", equipamento.idFornecedor);
            return View(equipamento);
        }

        [Authorize]
        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;
            Equipamento equipamento = db.Equipamento.Find(id);
            if (equipamento == null)
            {
                return HttpNotFound();
            }

            equipamento.status_ = (byte)Status.Inativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Aluno/Active/5
        [Authorize]
        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;
            Equipamento equipamento = db.Equipamento.Find(id);

            if (equipamento == null)
            {
                return HttpNotFound();
            }

            equipamento.status_ = (byte)Status.Ativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}