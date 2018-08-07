using EcommerceOsorioManha.DAO;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(ProdutoDAO.RetornarProdutos());
        }
        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (ProdutoDAO.SalvarProduto(produto))
                {
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível add o produto com o mesmo nome!");
                    return View(produto);
                }

            }
            else
            {
                return View(produto);
            }
            

        }

        public ActionResult RemoverProduto(int? Id)
        {
            ProdutoDAO.RemoverProduto(Id);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int? id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarProduto(Produto produtoAlterado)
        {
            Produto produtoOriginal = ProdutoDAO.BuscarProdutoPorId(produtoAlterado.ProdutoId);

            #region Atualiza o Produto
            
            produtoOriginal.Nome = produtoAlterado.Nome;
            produtoOriginal.Descricao = produtoAlterado.Descricao;
            produtoOriginal.Preco = produtoAlterado.Preco;
            produtoOriginal.Categoria = produtoAlterado.Categoria;

            #endregion  

            ProdutoDAO.AlterarProduto(produtoOriginal);

            return RedirectToAction("Index", "Produto");
        }


    }
}