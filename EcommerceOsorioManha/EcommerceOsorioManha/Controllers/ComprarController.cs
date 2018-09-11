using EcommerceOsorioManha.DAO;
using EcommerceOsorioManha.Models;
using EcommerceOsorioManha.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Controllers
{
	public class ComprarController : Controller
	{
		#region FinalizarCompra()
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

			if (TempData["Cliente"] != null)
			{
				return View(TempData["Cliente"]);
			}

			return View(cliente);
		}
		#endregion

		#region FinalizarCompra(Cliente)
		[HttpPost]
		public ActionResult FinalizarCompra(Cliente cliente)
		{
			string sessaoAtual = Sessao.RetornarCarrinhoId();
			cliente.CarrinhoId = sessaoAtual;
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
		#endregion

		#region PesquisarCEP(string)
		[HttpPost]
		public ActionResult PesquisarCEP(Cliente cliente)
		{
			try
			{
				//Download da string em Json
				string url = "https://viacep.com.br/ws/" + cliente.Cep + "/json/";
				WebClient client = new WebClient();
				string Json = client.DownloadString(url);

				//transformando o array de bytes em string para converter para UTF-8
				byte[] bytes = Encoding.Default.GetBytes(Json);
				Json = Encoding.UTF8.GetString(bytes);

				//Converter Json para objeto
				cliente = JsonConvert.DeserializeObject<Cliente>(Json);

				//Passar informacao para qualquer action do controller em vigor.
				TempData["Cliente"] = cliente;
			}
			catch (Exception)
			{
			}

			return RedirectToAction("FinalizarCompra", "Comprar");
		}
		#endregion

	}
}