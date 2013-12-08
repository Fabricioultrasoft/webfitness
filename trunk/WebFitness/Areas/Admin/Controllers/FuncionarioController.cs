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
    public class FuncionarioController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Funcionário";

        public bool VerificaCpf(string cpf)
        {

            return false;
        }

        //
        // GET: /Admin/Funcionario/

        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var funcionario = db.Funcionario.Include(f => f.Cidade);
            return View(funcionario.ToList());
        }

        //
        // GET: /Admin/Funcionario/Details/5

        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        //
        // GET: /Admin/Funcionario/Create

        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade");
            return View();
        }

        //
        // POST: /Admin/Funcionario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            @ViewBag.Controller = controller;
            funcionario.dtCriacao = DateTime.Now;
            funcionario.status = (byte)Status.Ativo;
            funcionario.idFuncionario = 1;
            funcionario.senha = Validation.GetMD5Hash(funcionario.senha);
            funcionario.nome = Validation.SyntaxName(funcionario.nome);

            if (ModelState.IsValid)
            {
                db.Funcionario.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", funcionario.idCidade);
            return View(funcionario);
        }

        //
        // GET: /Admin/Funcionario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", funcionario.idCidade);
            return View(funcionario);
        }

        //
        // POST: /Admin/Funcionario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Funcionario funcionario)
        {
            @ViewBag.Controller = controller;
            
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;

                if (funcionario.senha != null)
                {
                    funcionario.senha = Validation.GetMD5Hash(funcionario.senha);
                }
                else
                {
                    var rs = from funcionarioTmp in db.Funcionario where funcionarioTmp.idFuncionario == funcionario.idFuncionario select funcionarioTmp.senha;

                    foreach (var item in rs)
                    {
                        funcionario.senha = item.ToString();
                    }

                }

                funcionario.nome = Validation.SyntaxName(funcionario.nome);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", funcionario.idCidade);
            return View(funcionario);
        }

        //
        // GET: /Admin/Funcionario/Delete/5

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

            fornecedor.status = (byte) Status.Ativo;
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