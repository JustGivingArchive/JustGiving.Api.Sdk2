using System;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Serialization;
using RestSharp;
using RestSharp.Serializers;

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

        protected IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
        {
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            IRestResponse<T> response = null;
            try
            {
                response = _restClient.Execute<T>(request);
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

        protected IRestResponse Execute(IRestRequest request)
        {
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = null;
            try
            {
                response = _restClient.Execute(request);
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