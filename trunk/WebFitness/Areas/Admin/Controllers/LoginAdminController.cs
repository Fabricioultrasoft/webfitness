using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebFitness.classes;

namespace WebFitness.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        private WebfitnessDBEntities db = new WebfitnessDBEntities();
        private String controller = "LoginAdmin";

        //
        // GET: /Admin/LoginAdmin/Create

        public ActionResult Login()
        {
            @ViewBag.Controller = controller;
            return View();
        }

        //
        // POST: /Admin/LoginAdmin/Create

        [HttpPost]
        public ActionResult Login(Funcionario funcionario, String ReturnUrl)
        {
            @ViewBag.Controller = controller;
            string senha = Validation.GetMD5Hash(funcionario.senha);

            /*
            var user = (from funcionarioTmp
                       in db.Funcionario
                       where funcionarioTmp.login == funcionario.login
                          && funcionarioTmp.senha == senha
                       select funcionarioTmp ).First();
            */
            try
            {
                Funcionario user = (from u
                                      in db.Funcionario
                                    where u.login == funcionario.login
                                       && u.senha == senha
                                    select u).First();

                FormsAuthentication.SetAuthCookie(user.nome, false);
                if (ReturnUrl == null)
                    return RedirectToAction("Index", "Dashboard");
                else
                    return Redirect(ReturnUrl);

                //return RedirectToAction("Login");
            }
            catch
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}