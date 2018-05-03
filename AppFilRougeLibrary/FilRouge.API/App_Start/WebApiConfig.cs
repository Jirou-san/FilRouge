using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace FilRouge.API
{
    using Swashbuckle.Application;
    using System.Web.Http.Cors;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services de l'API Web
            // Configurer l'API Web pour utiliser uniquement l'authentification de jeton du porteur.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));




            // Itinéraires de l'API Web
            config.EnableSwagger(
                c =>
                    {
                        c.SingleApiVersion("v1", "FilRouge.API");
                        c.ApiKey("apiKey").Description("Bearer authentification token").Name("Authorization")
                            .In("header");
                    }).EnableSwaggerUi(c =>
                c.EnableApiKeySupport("Authorization", "header"));
            config.MapHttpAttributeRoutes();

            // Ajout MBa résolution problématique : No 'Access-Control-Allow-Origin'
            var cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
