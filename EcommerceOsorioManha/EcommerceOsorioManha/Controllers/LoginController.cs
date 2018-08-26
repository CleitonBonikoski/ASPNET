using EcommerceOsorioManha.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage(string nome, string senha)
        {
            if (Sessao.RetornarValidacaoLogin(nome,senha) != null)
                return RedirectToAction("Index", "Home");
                
            return View();
        }
    }
}