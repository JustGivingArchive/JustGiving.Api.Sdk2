using System;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients
{
    public abstract class ClientBase
    {
        private readonly IRestClient _restClient;
        private readonly ApiRequestLogger _logger;

        internal ClientBase(IRestClient client, ApiRequestLogger logger)
        {
            _restClient = client;
            _logger = logger;
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
    }
}