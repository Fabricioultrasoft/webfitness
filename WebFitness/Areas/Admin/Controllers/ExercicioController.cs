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
    public class ExercicioController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Exercício";

        //
        // GET: /Admin/Exercicio/
        [Authorize]
        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var exercicio = db.Exercicio.Include(e => e.TpExercicio);
            return View(exercicio.ToList());
        }

        //
        // GET: /Admin/Exercicio/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Exercicio exercicio = db.Exercicio.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        //
        // GET: /Admin/Exercicio/Create
        [Authorize]
        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idTpExercicio = new SelectList(db.TpExercicio, "idTpExercicio", "dsTpExercicio");
            return View();
        }

        //
        // POST: /Admin/Exercicio/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exercicio exercicio)
        {
            @ViewBag.Controller = controller;
            exercicio.dtCriacao = DateTime.Now;
            exercicio.status = (byte) Status.Ativo;
            exercicio.idExercicio = 1;
            exercicio.dsExercicio = Validation.SyntaxName(exercicio.dsExercicio);
            if (ModelState.IsValid)
            {
                db.Exercicio.Add(exercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTpExercicio = new SelectList(db.TpExercicio, "idTpExercicio", "dsTpExercicio", exercicio.idTpExercicio);
            return View(exercicio);
        }

        //
        // GET: /Admin/Exercicio/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Exercicio exercicio = db.Exercicio.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTpExercicio = new SelectList(db.TpExercicio, "idTpExercicio", "dsTpExercicio", exercicio.idTpExercicio);
            return View(exercicio);
        }

        //
        // POST: /Admin/Exercicio/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exercicio exercicio)
        {
            @ViewBag.Controller = controller;
            if (ModelState.IsValid)
            {
                db.Entry(exercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTpExercicio = new SelectList(db.TpExercicio, "idTpExercicio", "dsTpExercicio", exercicio.idTpExercicio);
            return View(exercicio);
        }

        [Authorize]
        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;
            Exercicio exercicio = db.Exercicio.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }

            exercicio.status = (byte)Status.Inativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Aluno/Active/5
        [Authorize]
        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;
            Exercicio exercicio = db.Exercicio.Find(id);

            if (exercicio == null)
            {
                return HttpNotFound();
            }

            exercicio.status = (byte)Status.Ativo;
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