using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Model.OneSearch.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.OneSearch
{
    public interface IOneSearchClient
    {
        Task<IRestResponse<OneSearchResponse>> OneSearchIndex(string phraseToSearch, int limit = 100, int offset = 0, bool groupSearch = false, string resultsByIndex = "", string country = "GB");
    }
}