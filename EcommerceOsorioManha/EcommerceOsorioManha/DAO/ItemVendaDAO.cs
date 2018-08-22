using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using EcommerceOsorioManha.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        // Caso adicionar seja true, então adiciona +1 ao carrinho
        // Caso adicionar seja false, então remove -1 do carrinho
        public static ItemVenda EditaQuantidadeItemVendaNoCarrinho(Produto produto, bool adicionar)
        {
            ItemVenda itemVenda = new ItemVenda();

            var sessaoId = Sessao.RetornarCarrinhoId();

            ItemVenda itemCarrinho = contexto.ItensVenda.FirstOrDefault(_ => _.Produto.ProdutoId == produto.ProdutoId && _.CarrinhoId == sessaoId);

            if (adicionar)
            {
                if (itemCarrinho == null)
                {
                    itemVenda.Quantidade = 1;
                }
                else
                {
                    RemoverItem(itemCarrinho.ItemVendaId);
                    itemVenda.Quantidade = ++itemCarrinho.Quantidade;
                }
            }
            else
            {
                if(!DiminuirItemAteUm(itemCarrinho))
                    RemoverItem(itemCarrinho.ItemVendaId);
            }

            itemVenda.Produto = produto;
            itemVenda.Preco = produto.Preco;
            itemVenda.Data = DateTime.Now;
            itemVenda.CarrinhoId = sessaoId;

            return itemVenda;
        }
        #endregion

        #region DiminuirItemAteUm(ItemVenda)
        internal static bool DiminuirItemAteUm(ItemVenda item)
        {
            try
            {
                if (item.Quantidade > 1)
                {
                    --item.Quantidade;

                    contexto.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;

        }
        #endregion

        #region BuscarProdutoPorItemId(int)
        internal static Produto BuscarProdutoPorItemId(int id)
        {
            ItemVenda item = contexto.ItensVenda.Find(id);

            return item.Produto;
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

        #region RetornarItemVendaPorId(int)
        public static ItemVenda RetornarItemVendaPorId(int IdItem)
        {
            return contexto.ItensVenda.Find(IdItem);
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

    }
}