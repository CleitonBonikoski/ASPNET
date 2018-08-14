using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            ViewBag.Categorias = 
                new SelectList(CategoriaDAO.RetornarCategorias(),
                "CategoriaID", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto, 
            int? Categorias, HttpPostedFileBase fupImagem)
        {
            ViewBag.Categorias =
                new SelectList(CategoriaDAO.RetornarCategorias(), 
                "CategoriaID", "Nome");
            if (ModelState.IsValid)


            {
                if (Categorias != null)
                {
                    if (fupImagem != null)
                    {
                        string nomeImagem = Path.GetFileName(fupImagem.FileName);
                        string caminho = Path.Combine(Server.MapPath("~/Imagens/"), 
                            nomeImagem);

                        fupImagem.SaveAs(caminho);

                        produto.Imagem = nomeImagem;

                    }
                    else
                    {
                        produto.Imagem = "semimagem.jpg";
                    }

                    produto.Categoria = CategoriaDAO.BuscarCategoriaPorId(Categorias);
                    if (ProdutoDAO.CadastrarProduto(produto))
                    {

                        return RedirectToAction("Index", "Produto");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Não é possivel um produto com o mesmo nome");
                        return View(produto);
                    }

                }
                ModelState.AddModelError("", "Por favor, selecione uma categoria!");
                return View(produto);
            }
            else
            {
                return View(produto);
            }
        }

        public ActionResult RemoverProduto(int? id)
        {

            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("Index", "Produto");

        }

        public ActionResult AlterarProduto(int? id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarProduto(Produto produtoAlterado)
        {
            Produto produtoOriginal =
            ProdutoDAO.BuscarProdutoPorId(produtoAlterado.ProdutoId);

            produtoOriginal.Nome = produtoAlterado.Nome;
            produtoOriginal.Descricao = produtoAlterado.Descricao;
            produtoOriginal.Preco = produtoAlterado.Preco;
            produtoOriginal.Categoria = produtoAlterado.Categoria;

            ProdutoDAO.AlterarProduto(produtoOriginal);

            return RedirectToAction("Index", "Produto");
        }

    }
}