using System.Collections.Generic;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Countries.Response;
using RestSharp;
using RestRequest = JustGiving.Api.Sdk2.Http.RestRequest;

namespace JustGiving.Api.Sdk2.Clients.Countries
{
    public class CountryClient : ClientBase, ICountryClient
    {
        internal CountryClient(IRestClient client, ApiRequestLogger logger) : base(client, logger)
        {
        }

        public async Task<IRestResponse<List<Country>>> ListCountries()
        {
            const string resource = "/v1/countries";
            var request = new RestRequest(resource, Method.GET);
            return await Execute<List<Country>>(request);
        }
    }
}
