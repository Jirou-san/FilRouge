using System;
using System.Collections.Generic;
using System.Text;

namespace FilRouge.HttpHandler
{
    using System.Net.Http;

    using Newtonsoft.Json;
    /// <summary>
    /// Classe non instanciée permettant uniquement l'accès au token
    /// </summary>
    public class TokenResponse
    {
        //Accès au token
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
    }

    /// <summary>
    /// Classe instanciée uniquement pour la fonction Login --> Voir définition de la fonction
    /// </summary>
    public class HttpRequestHandler
    {
        //Définition d'un client
        public System.Net.Http.HttpClient client;
        //URI de base utilisée
        public string baseUri;
        //Token utilisé
        private string _token;

        public HttpRequestHandler(string baseUri)
        {
            this.baseUri = baseUri;
            this.client = new HttpClient();
        }

        /// <summary>
        /// Procédure Login qui permettra à un utilisateur de l'application de se connecter, il aura un token temporaire
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(string username, string password)
        {
            _token = client.PostAsFormAsync<TokenResponse>(
                $"{baseUri}/api/token",
                new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>(
                            "username",
                            username),
                        new KeyValuePair<string, string>(
                            "password",
                            password)
                    }).Result?.AccessToken;
            if (_token == null)
            {
                throw new ExceptionLogin("Identifiants invalides");
            }
        }
    }
}
