using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAO
{
    public class ProdutoDAO
    {
        private static Contexto contexto = new Contexto();

        public static List<Produto> RetornarProdutos()
        {
            try
            {
                return contexto.Produtos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SalvarProduto(Produto produto)
        {
            try
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();              
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public static Produto BuscarProdutoPorId(int? Id)
        {
            try
            {
                return contexto.Produtos.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }           
        }

        public static void RemoverProduto(int? Id)
        {
            try
            {
                contexto.Produtos.Remove(BuscarProdutoPorId(Id));
                contexto.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }          

        }

        public static void AlterarProduto(Produto produto)
        {
            try
            {
                contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}