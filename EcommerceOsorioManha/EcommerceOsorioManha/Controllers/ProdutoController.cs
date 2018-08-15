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
        private static Contexto contexto = SingletonContext.GetInstance();

        #region IndexProduto
        public ActionResult IndexProduto()
        {
            ViewBag.Data = DateTime.Now;
            return View(ProdutoDAO.RetornarProdutos());
        }
        #endregion

        #region RetornarProduto
        public static List<Produto> RetornarProduto()
        {
            return contexto.Produtos.ToList();
        }
        #endregion

        #region CadastrarProduto
        public ActionResult CadastrarProduto()
        {
            ViewBag.Categorias =
                new SelectList(CategoriaDAO.RetornarCategorias(),
                "CategoriaID", "Nome");
            return View();
        }
        #endregion

        #region CadastrarProduto(Produto,int?,HttpPostedFileBase)
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
                        return RedirectToAction("IndexProduto", "Produto");
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
        #endregion

        #region RemoverProduto(int?)
        public ActionResult RemoverProduto(int? id)
        {
            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("IndexProduto", "Produto");
        }
        #endregion

        #region AlterarProduto(int?)
        public ActionResult AlterarProduto(int? id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }
        #endregion

        #region AlterarProduto(Produto, HttpPostedFileBase)
        [HttpPost]
        public ActionResult AlterarProduto(Produto produtoAlterado, HttpPostedFileBase fupImagem)
        {
            Produto produtoOriginal =
            ProdutoDAO.BuscarProdutoPorId(produtoAlterado.ProdutoId);

            produtoOriginal.Nome = produtoAlterado.Nome;
            produtoOriginal.Descricao = produtoAlterado.Descricao;
            produtoOriginal.Preco = produtoAlterado.Preco;
            produtoOriginal.Categoria = produtoAlterado.Categoria;

            if (fupImagem != null)
            {
                string nomeImagem = Path.GetFileName(fupImagem.FileName);
                string caminho = Path.Combine(Server.MapPath("~/Imagens/"),
                    nomeImagem);

                fupImagem.SaveAs(caminho);

                produtoOriginal.Imagem = nomeImagem;
            }

            ProdutoDAO.AlterarProduto(produtoOriginal);

            return RedirectToAction("IndexProduto", "Produto");
        }
        #endregion

    } // End class

}//End namespace