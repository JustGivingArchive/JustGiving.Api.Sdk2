using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.OneSearch.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.OneSearch
{
    public class OneSearchClient : ClientBase, IOneSearchClient
    {
        internal OneSearchClient(IRestClient restClient, HttpClient httpClient, ApiRequestLogger logger) : base(restClient, httpClient, logger)
        {
        }

        public Task<IRestResponse<OneSearchResponse>> OneSearchIndex(string phraseToSearch, int limit = 100, int offset = 0, bool groupSearch = false,
            string resultsByIndex = "", string country = "GB")
        {
            var resource = OneSearchQueryFormat(phraseToSearch, groupSearch, resultsByIndex, limit, offset, country);
            var request = new Http.RestRequest(resource, Method.GET);
            var result = Execute<OneSearchResponse>(request);
            return result;
        }

        private string OneSearchQueryFormat(string phraseToSearch, bool groupSearch,
            string resultsByIndex, int limit, int offset, string country)
        {
            var locationFormat = "/v1/onesearch";
            locationFormat += "?q=" + Uri.EscapeDataString(phraseToSearch ?? string.Empty);
            locationFormat += "&g=" + groupSearch;
            locationFormat += "&i=" + resultsByIndex;
            locationFormat += "&limit=" + limit;
            locationFormat += "&offset=" + offset;
            locationFormat += "&country=" + country;
            return locationFormat;
        }
    }
}
