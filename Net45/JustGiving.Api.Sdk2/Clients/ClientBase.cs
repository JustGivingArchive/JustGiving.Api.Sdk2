using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients
{
    public abstract class ClientBase
    {
        private readonly IRestClient _restClient;
        private readonly HttpClient _httpClient;
        private readonly ApiRequestLogger _logger;

        internal ClientBase(IRestClient restClient, HttpClient httpClient, ApiRequestLogger logger)
        {
            _restClient = restClient;
            _logger = logger;
            _httpClient = httpClient;
        }

        protected async Task<IRestResponse<T>> Execute<T>(JustGiving.Api.Sdk2.Http.RestRequest request) where T : new()
        {
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            IRestResponse<T> response = null;
            try
            {
                response = await _restClient.ExecuteTaskAsync<T>(request);
            }
            catch (Exception e)
            {
                _logger.Error("An error occurred while executing an HTTP request", e);
                throw;
            }
            finally
            {
                _logger.LogRequest(request, response);
            }

            return response;
        }

        protected async Task<IRestResponse> Execute(JustGiving.Api.Sdk2.Http.RestRequest request)
        {
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = null;
            try
            {
                response = await _restClient.ExecuteTaskAsync(request);
            }
            catch (Exception e)
            {
                _logger.Error("An error occurred while executing an HTTP request", e);
                throw;
            }
            finally
            {
                _logger.LogRequest(request, response);
            }

            return response;
        }

        protected async Task<HttpResponseMessage> ExecuteRaw(string resource, HttpMethod method, byte[] data, string contentType)
        {
            var message = new System.Net.Http.HttpRequestMessage(method, resource)
            {
                Content = new ByteArrayContent(data)
            };

            message.Content.Headers.ContentType= new MediaTypeHeaderValue(contentType);

            var result = await _httpClient.SendAsync(message);

            return result;
        }
    }
}