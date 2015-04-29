using System.Collections.Generic;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using RestSharp;
using RestRequest = JustGiving.Api.Sdk2.Http.RestRequest;

namespace JustGiving.Api.Sdk2.Clients.Currency
{
    public class CurrencyClient : ClientBase, ICurrencyClient
    {
        internal CurrencyClient(IRestClient restClient, System.Net.Http.HttpClient httpClient, ApiRequestLogger logger) : base(restClient, httpClient, logger)
        {
        }

        public async Task<IRestResponse<List<Model.Currency.Response.Currency>>> GetValidCurrencyCodes()
        {
            const string resource = "/v1/fundraising/currencies";
            var request = new RestRequest(resource, Method.GET);
            return await Execute<List<Model.Currency.Response.Currency>>(request);
        }
    }
}
