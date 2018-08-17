using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAO
{
    public class ItemVendaDAO
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        public static bool AdicionarItemVendaAoCarrinho(ItemVenda itemVenda)
        {
            if (BuscarItemVendaPorId(itemVenda.ItemVendaId))
            {
                contexto.ItensVenda.Add(itemVenda);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        private static bool BuscarItemVendaPorId(int itemVendaId)
        {
            if (contexto.ItensVenda.Find(itemVendaId) != null)
            {
                return false;
            }
            return true;
        }
    }
}