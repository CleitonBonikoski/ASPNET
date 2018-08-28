using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;

namespace EcommerceOsorioManha.DAO
{
    public class ClienteDAO
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        #region CadastrarCompraCliente(Cliente)
        public static bool CadastrarCompraCliente(Cliente cliente)
        {
            try
            {
                contexto.clientes.Add(cliente);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        #endregion

    }
}