using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Models
{
	[Table("Login")]
	public class Login
	{
		[Key]
		public int LoginId { get; set; }

		[Required(ErrorMessage = "Nome do Login obrigatório!")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Senha do Login obrigatório!")]
		public string Senha { get; set; }

	}
}