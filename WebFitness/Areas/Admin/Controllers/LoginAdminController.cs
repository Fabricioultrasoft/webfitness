using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebFitness.Classes;

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

            //try
            //{
            Funcionario user = (from funcionarioTmp
                                  in db.Funcionario
                                where funcionarioTmp.login == funcionario.login
                                  && funcionarioTmp.senha == senha
                                select funcionarioTmp).First();

            FormsAuthentication.SetAuthCookie(user.nome, false);
            Session["FUNCIONARIO"] = user;

            if (!String.IsNullOrEmpty(ReturnUrl))
                return Redirect(ReturnUrl);
            else
                return RedirectToAction("Index", "Dashboard");


            //}
            //catch
            //{
            //    return RedirectToAction("Login");
            //}
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Forget()
        {
            @ViewBag.Controller = controller;
            Session.Clear();
            return View();
        }

        //
        // POST: /Admin/LoginAdmin/Create

        [HttpPost]
        public ActionResult Forget(Funcionario funcionario, String ReturnUrl)
        {
            @ViewBag.Controller = controller;
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}