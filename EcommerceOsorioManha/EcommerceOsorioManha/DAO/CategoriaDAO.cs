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

        public static List<Categoria> RetornarCategorias()
        {
            return contexto.Categorias.ToList();
        }

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

        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return contexto.Categorias.Find(id);

        }

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

        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            return contexto.Categorias.FirstOrDefault(x => x.Nome.Equals(categoria.Nome));
        }

    }
}