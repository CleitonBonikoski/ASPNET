using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceOsorioManha.Controllers
{
	[RoutePrefix("api/Produto")]
	public class ProdutoAPIController : ApiController
	{
		//Get: api/Produto/Produtos
		[Route("Produtos")]
		public List<Produto> GetProdutos()
		{
			return ProdutoDAO.RetornarProdutos();
		}

		//Get: api/Produto/ProdutosPorCategoria/comida
		[Route("ProdutosPorCategoria/{CategoriaId}")]
		public List<Produto> GetProdutosPorCategoria(string CategoriaId)
		{
			return ProdutoDAO.RetornarProdutosPorCategoria(CategoriaId);
		}

		//Get: api/Produto/ProdutosPorId/2
		[Route("ProdutosPorId/{ProdutoId}")]
		public dynamic GetProdutosPorId(int ProdutoId)
		{
			Produto produto = ProdutoDAO.BuscarProdutoPorId(ProdutoId);
			List<Categoria> categorias = CategoriaDAO.RetornarCategorias();
			if (produto != null)
			{
				dynamic produtoDynamic = new
				{
					Nome = produto.Nome,
					Preco = produto.Preco.ToString("C2"),
					Categorias = categorias,
					DataEnvio = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
				};
				return new { produto = produtoDynamic };
			}

			return NotFound();
		}
	}
}
