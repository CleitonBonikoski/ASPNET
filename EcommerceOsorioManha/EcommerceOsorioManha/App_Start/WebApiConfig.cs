using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EcommerceOsorioManha
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

			// Mudar formato da entrega da webapi
			//De XML para Json
			config.Formatters.Remove(config.Formatters.XmlFormatter);
			config.Formatters.JsonFormatter.Indent = true;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
