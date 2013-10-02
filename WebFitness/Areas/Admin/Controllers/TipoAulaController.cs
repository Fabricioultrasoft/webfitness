using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFitness.Areas.Admin.Controllers
{
    public class TipoAulaController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Tipo Aula";
        //
        // GET: /Admin/TipoAula/

        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            return View(db.TpAula.ToList());
        }

        //
        // GET: /Admin/TipoAula/Create

        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            return View();
        }

        //
        // POST: /Admin/TipoAula/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TpAula tpaula)
        {
            if (ModelState.IsValid)
            {
                tpaula.dtCriacao = DateTime.Now;
                tpaula.idTpAula = 1;
                tpaula.status = 1;

                db.TpAula.Add(tpaula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tpaula);
        }

        //
        // GET: /Admin/TipoAula/Edit/5

        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;

            TpAula tpaula = db.TpAula.Find(id);
            if (tpaula == null)
            {
                return HttpNotFound();
            }
            return View(tpaula);
        }

        //
        // POST: /Admin/TipoAula/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TpAula tpaula)
        {
            @ViewBag.Controller = controller;

            if (ModelState.IsValid)
            {
                db.Entry(tpaula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tpaula);
        }

        //
        // GET: /Admin/TipoAula/Inactive/5

        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;

            TpAula tpaula = db.TpAula.Find(id);
            if (tpaula == null)
            {
                return HttpNotFound();
            }
            tpaula.status = 0;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/TipoAula/Active/5
        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;

            TpAula tpaula = db.TpAula.Find(id);
            if (tpaula == null)
            {
                return HttpNotFound();
            }
            tpaula.status = 1;
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