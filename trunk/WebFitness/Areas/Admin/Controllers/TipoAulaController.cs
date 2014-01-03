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
    public class TipoAulaController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Tipo Aula";
        //
        // GET: /Admin/TipoAula/
        [Authorize]
        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            return View(db.TpAula.ToList());
        }

        //
        // GET: /Admin/TipoAula/Create
        [Authorize]
        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            return View();
        }

        //
        // POST: /Admin/TipoAula/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TpAula tpaula)
        {

            tpaula.dsTpAula = Validation.SyntaxName(tpaula.dsTpAula);
            tpaula.dtCriacao = DateTime.Now;
            tpaula.idTpAula = 1;
            tpaula.status = (byte)Status.Ativo;

            if (ModelState.IsValid)
            {
                db.TpAula.Add(tpaula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tpaula);
        }

        //
        // GET: /Admin/TipoAula/Edit/5
        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TpAula tpaula)
        {
            @ViewBag.Controller = controller;
            tpaula.dsTpAula = Validation.SyntaxName(tpaula.dsTpAula);

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
        [Authorize]
        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;

            TpAula tpaula = db.TpAula.Find(id);
            if (tpaula == null)
            {
                return HttpNotFound();
            }
            tpaula.status = (byte) Status.Inativo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/TipoAula/Active/5
        [Authorize]
        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;

            TpAula tpaula = db.TpAula.Find(id);
            if (tpaula == null)
            {
                return HttpNotFound();
            }
            tpaula.status = (byte) Status.Ativo;
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