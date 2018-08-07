using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório !")]
        [MaxLength(50, ErrorMessage ="Tamanho máximo de 50 letras")]
        [Display(Name ="Nome do Produto")]
        public string Nome { get; set; }

        [Display(Name = "Descrição do Produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [Range(0,1000)]
        [Display(Name = "Preço do Produto")]
        public double Preco { get; set; }

        [Display(Name = "Categoria do Produto")]
        public string Categoria { get; set; }

        public string Imagem { get; set; }

    }
}