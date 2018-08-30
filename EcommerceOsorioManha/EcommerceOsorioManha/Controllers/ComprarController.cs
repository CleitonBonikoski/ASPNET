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
    public class ComprarController : Controller
    {
        // GET: Comprar
        public ActionResult FinalizarCompra()
        {
            string sessaoAtual = Sessao.RetornarCarrinhoId();

            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            List<ItemVenda> lstItensVenda = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(Sessao.RetornarCarrinhoId());

            ViewBag.lstItensVenda = lstItensVenda;

            Cliente cliente = new Cliente();

            foreach (ItemVenda item in lstItensVenda)
            {
                cliente.CarrinhoId = item.CarrinhoId;
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult FinalizarCompra(Cliente cliente)
        {

            string sessaoAtual = Sessao.RetornarCarrinhoId();

            if (ClienteDAO.CadastrarCompraCliente(cliente))
            {
                ItemVendaDAO.AlterarStatusCompra(cliente);

                Sessao.FinalizarSessaoCarrinhoId();

                sessaoAtual = Sessao.RetornarCarrinhoId();

                ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

                ViewBag.lstItensVenda = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(Sessao.RetornarCarrinhoId());

                return RedirectToAction("Index", "Home");
            }

            ViewBag.QuantidadeNoCarrinho = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(sessaoAtual);

            ViewBag.lstItensVenda = ItemVendaDAO.BuscarItensVendaPorCarrinhoId(Sessao.RetornarCarrinhoId());

            return View(cliente);

        }
    }
}