using System;
using System.Net.Http;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Search.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Search
{
    public interface ISearchClient
    {
        Task<IRestResponse<CharitySearchResults>> CharitySearch(string searchTerms, int pageNumber = 1, int pageSize = 100);
    }
    public class SearchClient : ClientBase, ISearchClient
    {
        internal SearchClient(IRestClient restClient, HttpClient httpClient, ApiRequestLogger logger) : base(restClient, httpClient, logger)
        {
        }

        public async Task<IRestResponse<CharitySearchResults>> CharitySearch(string searchTerms, int pageNumber = 1, int pageSize = 100)
        {
            var resource = CharitySearchLocationFormat(searchTerms, pageNumber, pageSize);
            var request = new Http.RestRequest(resource, Method.GET);
            var result = await Execute<CharitySearchResults>(request);
            return result;
        }

        private string CharitySearchLocationFormat(string searchTerms, int? pageNumber, int? pageSize)
        {
            var locationFormat = "/v1/charity/search";
            locationFormat += "?q=" + Uri.EscapeDataString(searchTerms ?? string.Empty);
            locationFormat += "&page=" + pageNumber.GetValueOrDefault(1);
            locationFormat += "&pageSize=" + pageSize.GetValueOrDefault(20);
            return locationFormat;
        }
    }
}
