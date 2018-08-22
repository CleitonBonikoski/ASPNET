using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using EcommerceOsorioManha.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAO
{
    public class ItemVendaDAO
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        #region  AdicionarItemVendaAoCarrinho(ItemVenda)
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
        #endregion

        #region EditaQuantidadeItemVendaNoCarrinho(Produto)
        public static ItemVenda EditaQuantidadeItemVendaNoCarrinho(Produto produto)
        {
            ItemVenda itemVenda = new ItemVenda();

            var sessaoId = Sessao.RetornarCarrinhoId();

            ItemVenda itemCarrinho = contexto.ItensVenda.FirstOrDefault(_ => _.Produto.ProdutoId == produto.ProdutoId && _.CarrinhoId == sessaoId);

            if (itemCarrinho == null)
                itemVenda.Quantidade = 1;
            else
            {
                ItemVendaDAO.RemoverItem(itemCarrinho.ItemVendaId);
                itemVenda.Quantidade = ++itemCarrinho.Quantidade;
            }

            itemVenda.Produto = produto;
            itemVenda.Preco = produto.Preco;
            itemVenda.Data = DateTime.Now;
            itemVenda.CarrinhoId = sessaoId;

            return itemVenda;
        }
        #endregion

        #region BuscarItemVendaPorId(int)
        private static bool BuscarItemVendaPorId(int itemVendaId)
        {
            if (contexto.ItensVenda.Find(itemVendaId) != null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region BuscarItensVendaPorCarrinhoId(string)
        public static List<ItemVenda> BuscarItensVendaPorCarrinhoId(string carrinhoId)
        {
            return contexto.ItensVenda.Include("Produto").
                Where(_ => _.CarrinhoId.Equals(carrinhoId)).ToList();
        }
        #endregion

        #region RemoverItem(int)
        public static void RemoverItem(int Id)
        {
            contexto.ItensVenda.Remove(RetornarItemVendaPorId(Id));
            contexto.SaveChanges();
        }
        #endregion

        #region RetornarItemVendaPorId(int)
        private static ItemVenda RetornarItemVendaPorId(int id)
        {
            return contexto.ItensVenda.Find(id);
        }
        #endregion
    }
}