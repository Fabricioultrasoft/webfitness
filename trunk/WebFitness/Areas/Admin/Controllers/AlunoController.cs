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
    public class AlunoController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Aluno";

        //
        // GET: /Admin/Aluno/

        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var aluno = db.Aluno.Include(a => a.Cidade);
            return View(aluno.ToList());
        }

        //
        // GET: /Admin/Aluno/Details/5

        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        //
        // GET: /Admin/Aluno/Create

        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade");
            return View();
        }

        //
        // POST: /Admin/Aluno/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {
            @ViewBag.Controller = controller;
            aluno.dtCriacao = DateTime.Now;
            aluno.status    = (byte)Status.Ativo;
            aluno.idAluno   = 1;
            aluno.senha     = Validation.GetMD5Hash(aluno.senha);

            if (ModelState.IsValid)
            {
                db.Aluno.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", aluno.idCidade);
            return View(aluno);
        }

        //
        // GET: /Admin/Aluno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", aluno.idCidade);
            return View(aluno);
        }

        //
        // POST: /Admin/Aluno/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno aluno)
        {
            @ViewBag.Controller = controller;
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", aluno.idCidade);
            return View(aluno);
        }

        //
        // GET: /Admin/Aluno/Inactive/5

        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }

            aluno.status = (byte) Status.Inativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Aluno/Active/5

        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aluno aluno = db.Aluno.Find(id);
            
            if (aluno == null)
            {
                return HttpNotFound();
            }

            aluno.status = (byte)Status.Ativo;
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