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
    public class AulaController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();

        //
        // GET: /Admin/Aula/

        public ActionResult Index()
        {
            var aula = db.Aula.Include(a => a.TpAula);
            return View(aula.ToList());
        }

        //
        // GET: /Admin/Aula/Details/5

        public ActionResult Details(int id = 0)
        {
            Aula aula = db.Aula.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        //
        // GET: /Admin/Aula/Create

        public ActionResult Create()
        {
            ViewBag.idTpAula = new SelectList(db.TpAula, "idTpAula", "dsTpAula");
            return View();
        }

        //
        // POST: /Admin/Aula/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                aula.status = (byte)Status.Ativo;
                aula.dtCriacao = DateTime.Now;
                db.Aula.Add(aula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTpAula = new SelectList(db.TpAula, "idTpAula", "dsTpAula", aula.idTpAula);
            return View(aula);
        }

        //
        // GET: /Admin/Aula/Edit/5

        public ActionResult Edit(int id = 0)
        {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aula aula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTpAula = new SelectList(db.TpAula, "idTpAula", "dsTpAula", aula.idTpAula);
            return View(aula);
        }

        //
        // GET: /Admin/Aula/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Aula aula = db.Aula.Find(id);
            if (aula == null)
            {
                return HttpNotFound();
            }
            return View(aula);
        }

        //
        // POST: /Admin/Aula/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aula aula = db.Aula.Find(id);
            db.Aula.Remove(aula);
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