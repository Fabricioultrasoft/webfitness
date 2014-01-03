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
    public class ManutencaoController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Manutenção";

        //
        // GET: /Admin/Manutencao/
        [Authorize]
        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var manutencao = db.Manutencao.Include(m => m.Equipamento).Include(m => m.Fornecedor).Include(m => m.TpManutencao);
            return View(manutencao.ToList());
        }

        //
        // GET: /Admin/Manutencao/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Manutencao manutencao = db.Manutencao.Find(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            return View(manutencao);
        }

        //
        // GET: /Admin/Manutencao/Create
        [Authorize]
        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idEquipamento = new SelectList(db.Equipamento, "idEquipamento", "dsEquipamento");
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "dsFornecedor");
            ViewBag.idTpManutencao = new SelectList(db.TpManutencao, "idTpManutencao", "dsTpManutencao");
            return View();
        }

        //
        // POST: /Admin/Manutencao/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manutencao manutencao)
        {
            @ViewBag.Controller = controller;
            manutencao.idManutencao = 1;
            manutencao.dtCriacao = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Manutencao.Add(manutencao);
                db.SaveChanges();

                ContasPagar contaspagar = new ContasPagar();
                contaspagar.dsContasPagar = Validation.SyntaxName("manutenção");
                contaspagar.dtVencimento = manutencao.dtManutencao;
                contaspagar.valor = manutencao.valorManutencao;
                contaspagar.tpRegistro = (byte)TipoContasPagar.Manutencao;
                contaspagar.idTabelaFK = (from manutencaoTmp
                                            in db.Manutencao
                                        select manutencaoTmp.idManutencao).Max();
                db.ContasPagar.Add(contaspagar);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.idEquipamento = new SelectList(db.Equipamento, "idEquipamento", "dsEquipamento", manutencao.idEquipamento);
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "dsFornecedor", manutencao.idFornecedor);
            ViewBag.idTpManutencao = new SelectList(db.TpManutencao, "idTpManutencao", "dsTpManutencao", manutencao.idTpManutencao);
            return View(manutencao);
        }

        //
        // GET: /Admin/Manutencao/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Manutencao manutencao = db.Manutencao.Find(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEquipamento = new SelectList(db.Equipamento, "idEquipamento", "dsEquipamento", manutencao.idEquipamento);
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "dsFornecedor", manutencao.idFornecedor);
            ViewBag.idTpManutencao = new SelectList(db.TpManutencao, "idTpManutencao", "dsTpManutencao", manutencao.idTpManutencao);
            return View(manutencao);
        }

        //
        // POST: /Admin/Manutencao/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Manutencao manutencao)
        {
            @ViewBag.Controller = controller;
            if (ModelState.IsValid)
            {
                db.Entry(manutencao).State = EntityState.Modified;
                db.SaveChanges();
                try
                {
                    ContasPagar contaspagar = (from cpgTmp
                                                 in db.ContasPagar
                                               where cpgTmp.idTabelaFK == manutencao.idManutencao
                                                  && cpgTmp.tpRegistro == (byte)TipoContasPagar.Manutencao
                                               select cpgTmp).FirstOrDefault();

                    contaspagar.valor = manutencao.valorManutencao;
                    contaspagar.dtVencimento = manutencao.dtManutencao;
                    db.Entry(contaspagar).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch { }

                return RedirectToAction("Index");
            }
            ViewBag.idEquipamento = new SelectList(db.Equipamento, "idEquipamento", "dsEquipamento", manutencao.idEquipamento);
            ViewBag.idFornecedor = new SelectList(db.Fornecedor, "idFornecedor", "dsFornecedor", manutencao.idFornecedor);
            ViewBag.idTpManutencao = new SelectList(db.TpManutencao, "idTpManutencao", "dsTpManutencao", manutencao.idTpManutencao);
            return View(manutencao);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            @ViewBag.Controller = controller;
            Manutencao manutencao = db.Manutencao.Find(id);

            if (manutencao == null)
            {
                return HttpNotFound();
            }
            db.Manutencao.Remove(manutencao);
            db.SaveChanges();

            try
            {
                ContasPagar contaspagar = (from cpgTmp
                                                 in db.ContasPagar
                                           where cpgTmp.idTabelaFK == manutencao.idManutencao
                                              && cpgTmp.tpRegistro == (byte)TipoContasPagar.Manutencao
                                           select cpgTmp).FirstOrDefault();
                db.ContasPagar.Remove(contaspagar);
                db.SaveChanges();
            }
            catch {}

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}