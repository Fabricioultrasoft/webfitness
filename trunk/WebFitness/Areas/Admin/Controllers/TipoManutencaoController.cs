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
    public class TipoManutencaoController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Tipo Manutenção";

        //
        // GET: /Admin/TipoConserto/
        [Authorize]
        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            return View(db.TpManutencao.ToList());
        }

        //
        // GET: /Admin/TipoConserto/Create
        [Authorize]
        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            return View();
        }

        //
        // POST: /Admin/TipoConserto/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TpManutencao tpmanutencao)
        {
            tpmanutencao.dtCriacao = DateTime.Now;
            tpmanutencao.status = (byte) Status.Ativo;
            tpmanutencao.idTpManutencao = 1;
            tpmanutencao.dsTpManutencao = Validation.SyntaxName(tpmanutencao.dsTpManutencao);

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
        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TpManutencao tpmanutencao)
        {
            @ViewBag.Controller = controller;
            tpmanutencao.dsTpManutencao = Validation.SyntaxName(tpmanutencao.dsTpManutencao);
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
        [Authorize]
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
        [Authorize]
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