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
            ProdutoDAO.SalvarProduto(produto);

            return RedirectToAction("Index","Produto");

        }

        public ActionResult RemoverProduto(int? Id)
        {
            ProdutoDAO.RemoverProduto(Id);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int? id)
        {
            ViewBag.ProdutoAlteracao = ProdutoDAO.BuscarProdutoPorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult AlterarProduto(int TxtId, string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(TxtId);

            #region Atualiza o Produto

            produto.ProdutoId = TxtId;
            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = Convert.ToDouble(txtPreco);
            produto.Categoria = txtCategoria;

            #endregion  

            ProdutoDAO.AlterarProduto(produto);

            return RedirectToAction("Index", "Produto");
        }


    }
}