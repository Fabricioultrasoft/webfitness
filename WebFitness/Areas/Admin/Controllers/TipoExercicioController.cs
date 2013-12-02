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
    public class TipoExercicioController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Tipo Exercício";

        //
        // GET: /Admin/TipoEquipamento/

        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            return View(db.TpExercicio.ToList());
        }

        //
        // GET: /Admin/TipoEquipamento/Create

        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            return View();
        }

        //
        // POST: /Admin/TipoEquipamento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TpExercicio tpexercicio)
        {
            @ViewBag.Controller = controller;

            tpexercicio.dtCriacao = DateTime.Now;
            tpexercicio.status = (byte) Status.Ativo;
            tpexercicio.idTpExercicio = 1;
            tpexercicio.dsTpExercicio = Validation.SyntaxName(tpexercicio.dsTpExercicio);

            if (ModelState.IsValid)
            {
                db.TpExercicio.Add(tpexercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tpexercicio);
        }

        //
        // GET: /Admin/TipoEquipamento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            TpExercicio tpexercicio = db.TpExercicio.Find(id);
            if (tpexercicio == null)
            {
                return HttpNotFound();
            }
            return View(tpexercicio);
        }

        //
        // POST: /Admin/TipoEquipamento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TpExercicio tpexercicio)
        {
            @ViewBag.Controller = controller;
            tpexercicio.dsTpExercicio = Validation.SyntaxName(tpexercicio.dsTpExercicio);
            if (ModelState.IsValid)
            {
                db.Entry(tpexercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tpexercicio);
        }

        //
        // GET: /Admin/TipoEquipamento/Inactive/5

        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;

            TpExercicio tpexercicio = db.TpExercicio.Find(id);

            if (tpexercicio == null)
            {
                return HttpNotFound();
            }
            tpexercicio.status = (byte) Status.Inativo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/TipoEquipamento/Active/5

        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;

            TpExercicio tpexercicio = db.TpExercicio.Find(id);

            if (tpexercicio == null)
            {
                return HttpNotFound();
            }
            tpexercicio.status = (byte) Status.Ativo;
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