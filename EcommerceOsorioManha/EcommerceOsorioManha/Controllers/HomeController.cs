using EcommerceOsorioManha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id , string cat)
        {
            if(id != null && id > 0)
            {
                ViewBag.ProdutoDetalhe = ProdutoDAO.BuscarProdutoPorId(id);
            }
            if (cat != null)
            {
                if (cat.Equals("Alimento"))
                {
                    return View(ProdutoDAO.RetornarProdutosPorCategoria(cat));
                }
                else if (cat.Equals("Casa"))
                {
                    return View(ProdutoDAO.RetornarProdutosPorCategoria(cat));

                }
                else if (cat.Equals("Automoveis"))
                {
                    return View(ProdutoDAO.RetornarProdutosPorCategoria(cat));

                }
            }            

            return View(ProdutoDAO.RetornarProdutos());
        }

        [HttpPost]
        public ActionResult DetalheProduto(int? id)
        {
            return View();
        }

    }
}