using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.DAO;
using EcommerceOsorioManha.Models;
using EcommerceOsorioManha.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class CategoriaController : Controller
    {
        #region IndexCategoria
        public ActionResult IndexCategoria()
        {
            string sessaoAtual = Sessao.RetornarCarrinhoId();

            if (Sessao.ValidarSessionLogin() == null)
                return RedirectToAction("LoginPage", "Login");
                
            ViewBag.Data = DateTime.Now;
            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            return View(CategoriaDAO.RetornarCategorias());
        }
        #endregion

        #region CadastrarCategoria
        public ActionResult CadastrarCategoria()
        {
            return View();
        }
        #endregion

        #region CadastrarCategoria(Categoria)
        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (CategoriaDAO.CadastrarCategoria(categoria))
                {
                    return RedirectToAction("IndexCategoria", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possivel uma categoria com o mesmo nome");
                    return View(categoria);
                }
            }
            else
            {
                return View(categoria);
            }
        }
        #endregion

        #region RemoverCategoria(int?)
        public ActionResult RemoverCategoria(int? id)
        {
            CategoriaDAO.RemoverCategoria(id);
            return RedirectToAction("IndexCategoria", "Categoria");
        }
        #endregion

        #region AlterarCategoria(int?)
        public ActionResult AlterarCategoria(int? id)
        {
            return View(CategoriaDAO.BuscarCategoriaPorId(id));
        }
        #endregion

        #region AlterarCategoria(Categoria)
        [HttpPost]
        public ActionResult AlterarCategoria(Categoria categoriaAlterada)
        {
            Categoria categoriaOriginal =
            CategoriaDAO.BuscarCategoriaPorId(categoriaAlterada.CategoriaID);

            categoriaOriginal.Nome = categoriaAlterada.Nome;
            categoriaOriginal.Descricao = categoriaAlterada.Descricao;

            CategoriaDAO.AlterarCategoria(categoriaOriginal);

            return RedirectToAction("IndexCategoria", "Categoria");
        }
        #endregion

    }
}