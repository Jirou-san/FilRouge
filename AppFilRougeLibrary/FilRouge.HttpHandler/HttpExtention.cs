using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace FilRouge.HttpHandler
{
    public static class HTTPClientExtension
    {
        #region PostAsForm
        public static async Task<T> PostAsFormAsync<T>(
            this System.Net.Http.HttpClient client,
            string uri,
            IEnumerable<KeyValuePair<string, string>> formData)
            where T : class
        {
            var formdata = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync(uri, formdata);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
        #endregion
        #region PostAsJson
        public static async Task<T> PostAsJsonAsync<T>(this HttpClient client, string uri, object body, string token = null) where T : class
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var content = await client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
            if (content.IsSuccessStatusCode)
            {
                var content1 = await content.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<T>(content1);
                return response;
            }

            return null;
        }
        #endregion
        #region PatchAsJson

        public static async Task<bool> PatchAsJsonAsync(
            this System.Net.Http.HttpClient client,
            string uri,
            object body,
            string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                client.DefaultRequestHeaders.Authorization = null;
            }
            var msg = new HttpRequestMessage(new HttpMethod("PATCH"), uri);
            msg.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(msg);

            return response.IsSuccessStatusCode;
        }
        #endregion
        #region DeleteAsync

        public static async Task<bool> DeleteAsync(this System.Net.Http.HttpClient client, string uri, string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                client.DefaultRequestHeaders.Authorization = null;
            }
            var response = await client.DeleteAsync(uri);

            return response.IsSuccessStatusCode;
        }
        #endregion
        #region GetAsync
        public static async Task<T> GetAsync<T>(this System.Net.Http.HttpClient client, string uri, string token = null) where T : class
        {
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
        #endregion
    }
}