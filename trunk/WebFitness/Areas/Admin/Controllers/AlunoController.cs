using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using WebFitness.classes;


namespace WebFitness.Areas.Admin.Controllers
{
    public class AlunoController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "Aluno";

        //
        // GET: /Admin/Aluno/

        public ActionResult Index()
        {
            @ViewBag.Controller = controller;
            var aluno = db.Aluno.Include(a => a.Cidade);
            return View(aluno.ToList());
        }

        //
        // GET: /Admin/Aluno/Details/5

        public ActionResult Details(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        //
        // GET: /Admin/Aluno/Create

        public ActionResult Create()
        {
            @ViewBag.Controller = controller;
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade");
            return View();
        }

        //
        // POST: /Admin/Aluno/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno aluno)
        {

            @ViewBag.Controller = controller;
            aluno.dtCriacao = DateTime.Now;
            aluno.status    = (byte)Status.Ativo;
            aluno.idAluno   = 1;
            aluno.senha = Validation.GetMD5Hash(aluno.senha);
            aluno.nome = Validation.SyntaxName(aluno.nome);

            if (ModelState.IsValid)
            {
                db.Aluno.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", aluno.idCidade);
            return View(aluno);
        }

        //
        // GET: /Admin/Aluno/Edit/5

        public ActionResult Edit(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", aluno.idCidade);
            return View(aluno);
        }

        //
        // POST: /Admin/Aluno/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Aluno aluno)
        {
            @ViewBag.Controller = controller;
            aluno.nome = Validation.SyntaxName(aluno.nome);

            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                //
                if (aluno.senha != null)
                {
                    aluno.senha = Validation.GetMD5Hash(aluno.senha);
                }
                else
                {
                    var rs = from alunoTmp in db.Aluno 
                             where alunoTmp.idAluno == aluno.idAluno
                             select alunoTmp.senha;

                    foreach(var item in rs)
                        aluno.senha = item.ToString();

                }
                //
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCidade = new SelectList(db.Cidade, "idCidade", "dsCidade", aluno.idCidade);
            return View(aluno);
        }

        //
        // GET: /Admin/Aluno/Inactive/5

        public ActionResult Inactive(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }

            aluno.status = (byte) Status.Inativo;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Aluno/Active/5

        public ActionResult Active(int id = 0)
        {
            @ViewBag.Controller = controller;
            Aluno aluno = db.Aluno.Find(id);
            
            if (aluno == null)
            {
                return HttpNotFound();
            }

            aluno.status = (byte)Status.Ativo;
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
            String retorno_ctps = "False";

            try
            {
                Aluno aluno = (from u
                                         in db.Aluno
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
                Aluno aluno = (from u
                                         in db.Aluno
                                           where u.cpf == cpf
                                           select u).First();

                retorno_cpf = "True";

            }
            catch
            {
                retorno_cpf = "False";
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
            //FIM else decimal fora   



        }

        //Fim do metodo


       
    }
}