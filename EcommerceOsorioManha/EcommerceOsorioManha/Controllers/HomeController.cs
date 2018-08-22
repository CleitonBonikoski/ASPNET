using EcommerceOsorioManha.DAL;
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
                if (CategoriaDAO.BuscarCategoriaPorNome(cat))
                {
                    ViewBag.CategoriaMenu = CategoriaDAO.RetornarCategorias();

                    return View(ProdutoDAO.RetornarProdutosPorCategoria(cat));
                }
            }
            ViewBag.CategoriaMenu = CategoriaDAO.RetornarCategorias();

            return View(ProdutoDAO.RetornarProdutos());
        }    
        
        public ActionResult AdicionarAoCarrinho(int Id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(Id);

            ItemVenda itemVenda = ItemVendaDAO.EditaQuantidadeItemVendaNoCarrinho(produto);
            
            ItemVendaDAO.AdicionarItemVendaAoCarrinho(itemVenda);

            return RedirectToAction("CarrinhoCompras","Home");
        }

        public ActionResult CarrinhoCompras()
        {
            return View(ItemVendaDAO.BuscarItensVendaPorCarrinhoId(Sessao.RetornarCarrinhoId()));
        }

        public ActionResult RemoverItem(int Id)
        {
            ItemVendaDAO.RemoverItem(Id);
            return RedirectToAction("Index", "Home");
        }
    }
}