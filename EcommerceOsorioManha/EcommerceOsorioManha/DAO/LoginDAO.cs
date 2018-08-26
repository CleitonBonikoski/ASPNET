using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAO
{
    public class LoginDAO
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        #region CadastrarLogin(Login)
        public static bool CadastrarLogin(Login login)
        {
            if (BuscarLoginPorNome(login) == null)
            {
                contexto.logins.Add(login);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region BuscarLoginPorNome(Login)
        private static Login BuscarLoginPorNome(Login login)
        {
            return contexto.logins.Where(_ => _.Nome.Equals(login.Nome)).FirstOrDefault();
        }
        #endregion
    }
}