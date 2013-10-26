using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFitness.Areas.Admin.Controllers
{
    public class TipoManutencaoController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Tipo Manutenção";

        //
        // GET: /Admin/TipoConserto/

        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            return View(db.TpManutencao.ToList());
        }

        //
        // GET: /Admin/TipoConserto/Create

        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            return View();
        }

        //
        // POST: /Admin/TipoConserto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TpManutencao tpmanutencao)
        {
            tpmanutencao.dtCriacao = DateTime.Now;
            tpmanutencao.status = (byte) Status.Ativo;
            tpmanutencao.idTpManutencao = 1;

            @ViewBag.Controller = controller;
            if (ModelState.IsValid)
            {
                db.TpManutencao.Add(tpmanutencao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tpmanutencao);
        }

        //
        // GET: /Admin/TipoConserto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            TpManutencao tpmanutencao = db.TpManutencao.Find(id);
            if (tpmanutencao == null)
            {
                return HttpNotFound();
            }
            return View(tpmanutencao);
        }

        //
        // POST: /Admin/TipoConserto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TpManutencao tpmanutencao)
        {
            @ViewBag.Controller = controller;
            if (ModelState.IsValid)
            {
                db.Entry(tpmanutencao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tpmanutencao);
        }

        //
        // GET: /Admin/TipoConserto/Inactive/5

        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;
            TpManutencao tpmanutencao = db.TpManutencao.Find(id);
            if (tpmanutencao == null)
            {
                return HttpNotFound();
            }
            tpmanutencao.status = (byte) Status.Inativo;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/TipoConserto/Active/5
        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;
            TpManutencao tpmanutencao = db.TpManutencao.Find(id);
            if (tpmanutencao == null)
            {
                return HttpNotFound();
            }
            tpmanutencao.status = (byte) Status.Ativo;
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