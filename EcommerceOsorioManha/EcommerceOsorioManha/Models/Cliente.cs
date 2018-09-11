using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Telefone do Cliente")]
        public string TelefoneCliente { get; set; }

        public string CarrinhoId { get; set; }

		[Display(Name = "Cep")]
		public string Cep { get; set; }

		[Display(Name = "Endereço")]
		public string Logradouro { get; set; }

		[Display(Name = "Bairro")]
		public string Bairro { get; set; }

		[Display(Name = "Cidade")]
		public string Localidade { get; set; }

		[Display(Name = "Estado")]
		public string Uf { get; set; }

	}
}