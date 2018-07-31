using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Models
{
    public class Contexto : DbContext
    {
        // Nome do Banco
        public Contexto() : base("DbEcommerce") { }

        // Mapear as classes no banco
        public DbSet<Produto> Produtos { get; set; }
    }
}