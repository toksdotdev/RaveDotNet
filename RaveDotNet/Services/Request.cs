using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RaveDotNet.Services.JSONConverter;

namespace RaveDotNet.Services
{
    internal class Request
    {
        private readonly string _privateKey;

        public enum RequestMethod
        {
            Get,
            Post,
            Put,
            Delete
        };

        private readonly HttpClient _client;

        public Request(string privateKey, Uri baseApiAddress)
        {
            _privateKey = privateKey;

            _client = new HttpClient()
            {
                BaseAddress = baseApiAddress,
            };

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Sends http request to Host endpoint
        /// </summary>
        /// <param name="method">Method of request to send</param>
        /// <param name="endpoint">Subset rave endpoint to send request</param>
        /// <param name="body">Object data to send along with the http request</param>
        /// <returns>String of json data containing the response details</returns>
        public async Task<string> SendRequest(RequestMethod method, string endpoint, string body = null)
        {
            var result = string.Empty;
            
            var formsParams = new StringContent(body);

            try
            {
                #region Send Request

                HttpResponseMessage response;

                switch (method)
                {
                    case RequestMethod.Get:
                        response = await _client.GetAsync(endpoint);
                        break;

                    case RequestMethod.Post:
                        response = await _client.PostAsync(endpoint, formsParams);
                        response.EnsureSuccessStatusCode();
                        break;

                    case RequestMethod.Put:
                        response = await _client.PutAsync(endpoint, formsParams);
                        response.EnsureSuccessStatusCode();
                        break;

                    case RequestMethod.Delete:
                        response = await _client.DeleteAsync(endpoint);
                        break;

                    default:
                        throw new InvalidOperationException($"Invalid Request Method: {method}");
                }

                if (response != null && response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

                return result;

                #endregion Send Request
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}