﻿using EcommerceOsorioManha.DAL;
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
        string sessaoAtual = Sessao.RetornarCarrinhoId();

        #region Index(int?, string)
        public ActionResult Index(int? id , string cat)
        {
            if (id != null && id > 0)
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
            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            return View(ProdutoDAO.RetornarProdutos());
        }
        #endregion

        #region AdicionarAoCarrinho(int)
        public ActionResult AdicionarAoCarrinho(int Id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(Id);

            ItemVenda itemVenda = ItemVendaDAO.EditaQuantidadeItemVendaNoCarrinho(produto, true);
            
            ItemVendaDAO.AdicionarItemVendaAoCarrinho(itemVenda);

            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);
            
            return RedirectToAction("CarrinhoCompras","Home");
        }
        #endregion

        #region CarrinhoCompras()
        public ActionResult CarrinhoCompras()
        {
            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            return View(ItemVendaDAO.BuscarItensVendaPorCarrinhoId(Sessao.RetornarCarrinhoId()));
        }
        #endregion

        #region RemoverItem(int)
        public ActionResult RemoverItem(int Id)
        {
            Produto produto = ItemVendaDAO.BuscarProdutoPorItemId(Id);
            ItemVendaDAO.EditaQuantidadeItemVendaNoCarrinho(produto, false);

            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            return RedirectToAction("CarrinhoCompras", "Home");
        }
        #endregion

        #region DiminuirItem(int)
        public ActionResult DiminuirItem(int Id)
        {            
            ItemVendaDAO.DiminuirItemAteUm(ItemVendaDAO.RetornarItemVendaPorId(Id));

            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            return RedirectToAction("CarrinhoCompras", "Home");
        }
        #endregion

        #region AumentarItem(int)
        public ActionResult AumentarItem(int Id)
        {
            ItemVendaDAO.AumentarItemNoCarrinho(ItemVendaDAO.RetornarItemVendaPorId(Id));

            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            return RedirectToAction("CarrinhoCompras", "Home");
        }
        #endregion
        

    }
}