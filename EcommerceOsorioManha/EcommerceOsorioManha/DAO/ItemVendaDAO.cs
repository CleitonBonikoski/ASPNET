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

        public static List<ItemVenda> BuscarItensVendaPorCarrinhoId(string carrinhoId)
        {
            return contexto.ItensVenda.Include("Produto").
                Where(_ => _.CarrinhoId.Equals(carrinhoId)).ToList();
        }

        public static void RemoverItem(int Id)
        {
            contexto.ItensVenda.Remove(RetornarItemVendaPorId(Id));
            contexto.SaveChanges();
        }

        private static ItemVenda RetornarItemVendaPorId(int id)
        {
            return contexto.ItensVenda.Find(id);
        }
    }
}