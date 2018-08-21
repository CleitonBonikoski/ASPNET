using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.Utils
{
    public class Sessao
    {
        private static string NOME_SESSION = "CarrinhoId";

        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session[NOME_SESSION] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[NOME_SESSION] = guid;
            }
            return HttpContext.Current.Session[NOME_SESSION].ToString();
        }
    }
}