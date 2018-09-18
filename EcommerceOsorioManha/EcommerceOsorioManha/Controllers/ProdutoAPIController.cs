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
		[Route("Produtos")]
		public List<Produto> GetProdutos()
		{
			return ProdutoDAO.RetornarProdutos();
		}
    }
}
