using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
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
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(CategoriaDAO.RetornarCategorias());
        }

        public ActionResult CadastrarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)


            {
                if (CategoriaDAO.CadastrarCategoria(categoria))
                {

                    return RedirectToAction("Index", "Categoria");
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

        public ActionResult RemoverCategoria(int? id)
        {

            CategoriaDAO.RemoverCategoria(id);
            return RedirectToAction("Index", "Categoria");

        }

        public ActionResult AlterarCategoria(int? id)
        {
            return View(CategoriaDAO.BuscarCategoriaPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarCategoria(Categoria categoriaAlterada)
        {
            Categoria categoriaOriginal =
            CategoriaDAO.BuscarCategoriaPorId(categoriaAlterada.CategoriaID);

            categoriaOriginal.Nome = categoriaAlterada.Nome;
            categoriaOriginal.Descricao = categoriaAlterada.Descricao;
           
            CategoriaDAO.AlterarCategoria(categoriaOriginal);

            return RedirectToAction("Index", "Categoria");
        }
    }
}