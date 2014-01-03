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
    public class AulaController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Aula";

        //
        // GET: /Admin/Aula/
        [Authorize]
        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var aula = db.Aula.Include(a => a.TpAula);
            return View(aula.ToList());
        }

        //
        // GET: /Admin/Aula/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aula aula = db.Aula.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        //
        // GET: /Admin/Aula/Create
        [Authorize]
        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idTpAula = new SelectList(db.TpAula, "idTpAula", "dsTpAula");
            return View();
        }

        //
        // POST: /Admin/Aula/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aula aula)
        {
            @ViewBag.Controller = controller;
            if (ModelState.IsValid)
            {
                
                aula.status = (byte)Status.Ativo;
                aula.dtCriacao = DateTime.Now;
                aula.dsAula = Validation.SyntaxName(aula.dsAula);

                db.Aula.Add(aula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTpAula = new SelectList(db.TpAula, "idTpAula", "dsTpAula", aula.idTpAula);
            return View(aula);
        }

        //
        // GET: /Admin/Aula/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aula aula = db.Aula.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTpAula = new SelectList(db.TpAula, "idTpAula", "dsTpAula", aula.idTpAula);
            return View(aula);
        }

        //
        // POST: /Admin/Aula/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aula aula)
        {
            @ViewBag.Controller = controller;
            if (ModelState.IsValid)
            {
                db.Entry(aula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTpAula = new SelectList(db.TpAula, "idTpAula", "dsTpAula", aula.idTpAula);
            return View(aula);
        }

        [Authorize]
        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aula aula = db.Aula.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }

            aula.status = (byte)Status.Inativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Aluno/Active/5
        [Authorize]
        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aula aula = db.Aula.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }

            aula.status = (byte)Status.Ativo;
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