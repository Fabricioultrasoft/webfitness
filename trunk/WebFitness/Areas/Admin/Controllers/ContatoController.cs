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
    public class ContatoController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Contato";

        //
        // GET: /Admin/Contato/
        [Authorize]
        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            return View(db.Contato.OrderByDescending(x => x.dtCriacao).ToList());
        }

        //
        // GET: /Admin/Contato/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        //
        // GET: /Admin/Contato/Answer/5
        [Authorize]
        public ActionResult Answer(int id = 0)
        {
            @ViewBag.Controller = controller;
            Contato contato = db.Contato.Where(x => x.status == (byte)Status.Ativo && x.idContato == id).FirstOrDefault();//Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        //
        // POST: /Admin/Contato/Answer/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Answer(Contato contato)
        {
            @ViewBag.Controller = controller;
            Mail mail;

            if (ModelState.IsValid)
            {

                //try
                //{
                mail = new Mail(contato.email, contato.assuntoResposta, contato.mensagemResposta);
                mail.sendMail();
                //}
                //catch
                //{

                //}

                contato.status = (byte) Status.Inativo;
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}