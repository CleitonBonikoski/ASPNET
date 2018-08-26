using EcommerceOsorioManha.DAL;
using EcommerceOsorioManha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceOsorioManha.Utils
{
    public class Sessao
    {
        private static Contexto contexto = SingletonContext.GetInstance();

        #region Session
        private static string NOME_SESSION = "CarrinhoId";

        private static string LOGIN_SESSION = "LOGIN";
        #endregion

        #region  RetornarCarrinhoId()
        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session[NOME_SESSION] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[NOME_SESSION] = guid;
            }
            return HttpContext.Current.Session[NOME_SESSION].ToString();
        }
        #endregion

        #region ValidarSessionLogin()
        public static string ValidarSessionLogin()
        {
            if (HttpContext.Current.Session[LOGIN_SESSION] == null)
                return null;

            return HttpContext.Current.Session[LOGIN_SESSION].ToString();
        }
        #endregion

        #region RetornarValidacaoLogin()
        public static string RetornarValidacaoLogin(string nome, string senha)
        {
            if (HttpContext.Current.Session[LOGIN_SESSION] == null)
            {
                HttpContext.Current.Session[LOGIN_SESSION] =
                    contexto.logins.Where(_ => _.Nome.Equals(nome) && _.Senha.Equals(senha)).FirstOrDefault();
            }
            if (HttpContext.Current.Session[LOGIN_SESSION] != null)
                return HttpContext.Current.Session[LOGIN_SESSION].ToString();

            return null;
        }
        #endregion

    }
}