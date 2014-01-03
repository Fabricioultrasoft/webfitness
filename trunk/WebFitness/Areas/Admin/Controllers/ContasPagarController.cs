using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFitness.Classes;

namespace WebFitness.Areas.Admin
{
    public class ContasPagarController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();

        //
        // GET: /Admin/ContasPagar/

        public ActionResult Index()
        {
            return View(db.ContasPagar.ToList());
        }

        //
        // GET: /Admin/ContasPagar/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/ContasPagar/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContasPagar contaspagar)
        {
            contaspagar.idContasPagar = 1;
            contaspagar.tpRegistro = (byte) TipoContasPagar.Diversas;
            contaspagar.dsContasPagar = Validation.SyntaxName(contaspagar.dsContasPagar);

            if (ModelState.IsValid)
            {
                db.ContasPagar.Add(contaspagar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contaspagar);
        }

        //
        // GET: /Admin/ContasPagar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ContasPagar contaspagar = db.ContasPagar.Find(id);
            if (contaspagar == null)
            {
                return HttpNotFound();
            }
            return View(contaspagar);
        }

        //
        // POST: /Admin/ContasPagar/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContasPagar contaspagar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contaspagar).State = EntityState.Modified;
                db.SaveChanges();

                if ( contaspagar.tpRegistro == (byte) TipoContasPagar.Manutencao) 
                {
                    try
                    {
                        Manutencao manutencao = db.Manutencao.Find(contaspagar.idTabelaFK);
                        manutencao.valorManutencao = contaspagar.valor;
                        db.Entry(manutencao).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch { }
                }
                else if (contaspagar.tpRegistro == (byte)TipoContasPagar.Salario)
                {

                }
                return RedirectToAction("Index");
            }
            return View(contaspagar);
        }

        //
        // GET: /Admin/ContasPagar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ContasPagar contaspagar = db.ContasPagar.Find(id);
            if (contaspagar == null)
            {
                return HttpNotFound();
            }
            return View(contaspagar);
        }

        //
        // POST: /Admin/ContasPagar/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContasPagar contaspagar = db.ContasPagar.Find(id);
            db.ContasPagar.Remove(contaspagar);
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