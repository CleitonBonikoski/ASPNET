﻿using EcommerceOsorioManha.Models;
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
                return null;
            }
        }

        public static bool SalvarProduto(Produto produto)
        {
            if (BuscarProdutoPorNome(produto) == null)
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return contexto.Produtos.FirstOrDefault(x => x.Nome.Equals(produto.Nome));
        }

        public static Produto BuscarProdutoPorId(int? Id)
        {
            try
            {
                return contexto.Produtos.Find(Id);
            }
            catch (Exception)
            {
                return null;
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
            }

        }

    }
}