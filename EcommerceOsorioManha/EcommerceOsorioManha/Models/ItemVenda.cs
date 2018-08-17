using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Models
{
    public class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }

        public Produto produto { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }

        public DateTime Data { get; set; }
    }
}