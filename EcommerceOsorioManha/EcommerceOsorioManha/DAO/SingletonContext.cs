using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class SingletonContext
    {

        private static Contexto contexto;

        private SingletonContext() { }

        #region GetInstance()
        public static Contexto GetInstance()
        {
            if (contexto == null)
            {
                contexto = new Contexto();
            }
            return contexto;          
        }
        #endregion
    }
}