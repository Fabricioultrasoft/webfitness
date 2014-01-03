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
    public class FuncionarioController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Funcionário";

        public bool VerificaCpf(string cpf)
        {

            return false;
        }

        //
        // GET: /Admin/Funcionario/
        [Authorize]
        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var funcionario = db.Funcionario.Include(f => f.Cidade);
            return View(funcionario.ToList());
        }

        //
        // GET: /Admin/Funcionario/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        //
        // GET: /Admin/Funcionario/Create
        [Authorize]
        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade");
            return View();
        }

        //
        // POST: /Admin/Funcionario/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            @ViewBag.Controller = controller;
            funcionario.dtCriacao = DateTime.Now;
            funcionario.status = (byte)Status.Ativo;
            funcionario.idFuncionario = 1;
            funcionario.senha = Validation.GetMD5Hash(funcionario.senha);
            funcionario.nome = Validation.SyntaxName(funcionario.nome);

            if (ModelState.IsValid)
            {
                db.Funcionario.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", funcionario.idCidade);
            return View(funcionario);
        }

        //
        // GET: /Admin/Funcionario/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", funcionario.idCidade);
            return View(funcionario);
        }

        //
        // POST: /Admin/Funcionario/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Funcionario funcionario)
        {
            @ViewBag.Controller = controller;
            
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;

                if (funcionario.senha != null)
                {
                    funcionario.senha = Validation.GetMD5Hash(funcionario.senha);
                }
                else
                {
                    var rs = from funcionarioTmp in db.Funcionario where funcionarioTmp.idFuncionario == funcionario.idFuncionario select funcionarioTmp.senha;

                    foreach (var item in rs)
                    {
                        funcionario.senha = item.ToString();
                    }

                }

                funcionario.nome = Validation.SyntaxName(funcionario.nome);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", funcionario.idCidade);
            return View(funcionario);
        }

        //
        // GET: /Admin/Funcionario/Delete/5
        [Authorize]
        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }

            funcionario.status = (byte)Status.Inativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Aluno/Active/5
        [Authorize]
        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;
            Funcionario funcionario = db.Funcionario.Find(id);

            if (funcionario == null)
            {
                return HttpNotFound();
            }

            funcionario.status = (byte) Status.Ativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public string CheckDados(string cpf, string login, string ctps)
        {

            String retorno_login = "";
            String retorno_cpf = "";
            String retorno_ctps = "";

            try
            {
                Funcionario funcionario = (from u
                                         in db.Funcionario
                                           where u.login == login
                                           select u).First();

                retorno_login = "True";

            }
            catch
            {
                retorno_login = "False";
            }


            try
            {
                Funcionario funcionario = (from u
                                         in db.Funcionario
                                           where u.cpf == cpf
                                           select u).First();

                retorno_cpf = "True";

            }
            catch
            {
                retorno_cpf = "False";
            }


            try
            {
                Funcionario funcionario = (from u
                                         in db.Funcionario
                                           where u.ctps == ctps
                                           select u).First();

                retorno_ctps = "True";

            }
            catch
            {
                retorno_ctps = "False";
            }




            //true tem registro
            //false não tem registro
            if (retorno_cpf == "False" && retorno_login == "False" && retorno_ctps == "False")
            {
                return "False";
            }
            else
            {
                if (retorno_cpf == "True" && retorno_login == "False" && retorno_ctps == "False")
                {
                    return "cpf_true";
                }
                else
                {
                    if (retorno_cpf == "False" && retorno_login == "True" && retorno_ctps == "False")
                    {
                        return "login_true";
                    }
                    else
                    {
                        if (retorno_cpf == "False" && retorno_login == "False" && retorno_ctps == "True")
                        {
                            return "ctps_true";
                        }
                        else
                        {

                            if (retorno_cpf == "False" && retorno_login == "True" && retorno_ctps == "True")
                            {
                                return "login_ctps_true";
                            }
                            else
                            {
                                if (retorno_cpf == "True" && retorno_login == "False" && retorno_ctps == "True")
                                {
                                    return "cpf_ctps_true";
                                }
                                else
                                {

                                    if (retorno_cpf == "True" && retorno_login == "True" && retorno_ctps == "False")
                                    {
                                        return "cpf_login_true";
                                    }
                                    else
                                    {

                                        return "True";
                                    }


                                }

                            }

                        }

                    }
                }



            }

        }
    }
}