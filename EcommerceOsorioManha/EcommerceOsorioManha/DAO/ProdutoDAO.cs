using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class ProdutoDAO
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        #region RetornarProdutos()
        public static List<Produto> RetornarProdutos()
        {
            return contexto.Produtos.
                Include("Categoria").
                ToList();
        }
        #endregion

        #region RetornarProdutosPorCategoria(string)
        public static List<Produto> RetornarProdutosPorCategoria(string cat)
        {
            return contexto.Produtos.Where(x => x.Categoria.Nome.ToString().Contains(cat)).ToList();
        }
        #endregion

        #region CadastrarProduto(Produto)
        public static bool CadastrarProduto(Produto produto)
        {
            if (BuscarProdutoPorNome(produto) == null)
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region RemoverProduto(int?)
        public static void RemoverProduto(int? id)
        {
            try
            {
                contexto.Produtos.Remove(BuscarProdutoPorId(id));
                contexto.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region BuscarProdutoPorId(int?)
        public static Produto BuscarProdutoPorId(int? id)
        {
            return contexto.Produtos.Find(id);
        }
        #endregion

        #region AlterarProduto(Produto)
        public static void AlterarProduto(Produto produto)
        {
            try
            {
                contexto.Entry(produto).State = EntityState.Modified;
                contexto.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region BuscarProdutoPorNome(Produto)
        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return contexto.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }
        #endregion
    }
}