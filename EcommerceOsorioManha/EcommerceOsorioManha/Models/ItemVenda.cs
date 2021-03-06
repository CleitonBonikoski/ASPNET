﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Models
{
    [Table("ItemVenda")]
    public class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public double Preco { get; set; }

        public DateTime Data { get; set; }

        public string CarrinhoId { get; set; }

        public bool Comprado { get; set; }
    }
}