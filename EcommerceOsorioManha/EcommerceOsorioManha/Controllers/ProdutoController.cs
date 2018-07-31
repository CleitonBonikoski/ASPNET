﻿using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
    public class ProdutoController : Controller
    {
        Contexto contexto = new Contexto();

        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = contexto.Produtos.ToList();
            return View();
        }
        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = new Produto()
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = Convert.ToDouble(txtPreco),
                Categoria = txtCategoria
            };

            contexto.Produtos.Add(produto);
            contexto.SaveChanges();
            return RedirectToAction("Index","Produto");

        }

        public ActionResult RemoverProduto(int? id )
        {
            Produto ProdutoRemover = contexto.Produtos.Where(p => p.ProdutoId == id).FirstOrDefault();
            
            if (ProdutoRemover != null)
            {
                try
                {
                    contexto.Produtos.Remove(ProdutoRemover);
                    contexto.SaveChanges();
                }
                catch (Exception)
                {

                }

            }
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int? id)
        {
            Produto ProdutoAlteracao = contexto.Produtos.Find(id);
            ViewBag.ProdutoAlteracao = ProdutoAlteracao;
            return View();
        }


    }
}