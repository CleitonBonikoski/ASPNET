using EcommerceOsorioManha.DAO;
using EcommerceOsorioManha.Models;
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
            string sessaoAtual = Sessao.RetornarCarrinhoId();

            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            if (Sessao.RetornarValidacaoLogin(nome, senha) != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult CadastrarLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarLogin(string nome, string senha)
        {
            #region login
            Login login = new Login();
            login.Nome = nome;
            login.Senha = senha;
            #endregion

            if (LoginDAO.CadastrarLogin(login))
                return RedirectToAction("LoginPage", "Login");

            return View();
        }

        public ActionResult LogoutPage()
        {
            Sessao.FinalizarSessaoLogin();
            return RedirectToAction("LoginPage", "Login");
        }

    }
}