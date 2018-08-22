using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class CategoriaDAO
    {
        
        private static Contexto contexto = SingletonContext.GetInstance();

        #region RetornarCategorias()
        public static List<Categoria> RetornarCategorias()
        {
            return contexto.Categorias.ToList();
        }
        #endregion

        #region CadastrarCategoria(Categoria)
        public static bool CadastrarCategoria(Categoria categoria)
        {
            if (BuscarCategoriaPorNome(categoria) == null)
            {
                contexto.Categorias.Add(categoria);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region RemoverCategoria(int?)
        public static void RemoverCategoria(int? id)
        {
            try
            {
                contexto.Categorias.Remove(BuscarCategoriaPorId(id));
                contexto.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region BuscarCategoriaPorId(int?)
        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return contexto.Categorias.Find(id);
        }
        #endregion

        #region AlterarCategoria(Categoria)
        public static void AlterarCategoria(Categoria categoria)
        {
            try
            {
                contexto.Entry(categoria).State = EntityState.Modified;
                contexto.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region BuscarCategoriaPorNome(Categoria)
        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            return contexto.Categorias.FirstOrDefault(x => x.Nome.Equals(categoria.Nome));
        }
        #endregion

        #region BuscarCategoriaPorNome(string)
        public static bool BuscarCategoriaPorNome(string nomeCategoria)
        {
            if (contexto.Categorias.FirstOrDefault(x => x.Nome.Equals(nomeCategoria)) != null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}