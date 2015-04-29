using System.Collections.Generic;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Charity.Request;
using JustGiving.Api.Sdk2.Model.Charity.Response;
using RestSharp;
using RestRequest = JustGiving.Api.Sdk2.Http.RestRequest;

namespace JustGiving.Api.Sdk2.Clients.Charity
{
    public class CharityClient : ClientBase, ICharityClient
    {
        internal CharityClient(IRestClient restClient, System.Net.Http.HttpClient httpClient, ApiRequestLogger logger) : base(restClient, httpClient, logger)
        {
        }

        public async Task<IRestResponse<Model.Charity.Response.Charity>> GetCharityById(int charityId)
        {
            const string resource = "/v1/charity/{charityId}";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("charityId", charityId.ToString());
            return await Execute<Model.Charity.Response.Charity>(request);
        }

        public async Task<IRestResponse<GetEventsByCharityIdResponse>> GetEventsByCharityId(int charityId, int pageNum = 0, int pageSize = 150)
        {
            const string resource = "/v1/charity/{charityId}/events";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("charityId", charityId.ToString());
            return await Execute<GetEventsByCharityIdResponse>(request);
        }

        public async Task<IRestResponse<CharityDonations>> GetCharityDonations(int charityId)
        {
            const string resource = "/v1/charity/{charityId}/donations";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("charityId", charityId.ToString());
            return await Execute<CharityDonations>(request);
        }
        public async Task<IRestResponse> CharityDeleteFundraisingPageAttribution(int charityId, string pageShortName)
        {
            const string resource = "/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new RestRequest(resource, Method.DELETE);
            request.AddUrlSegment("charityId", charityId.ToString());
            request.AddUrlSegment("pageShortName", pageShortName);
            return await Execute(request);
        }

        public async Task<IRestResponse> CharityUpdateFundraisingPageAttribution(int charityId, string pageShortName, string attribution)
        {
            const string resource = "/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new RestRequest(resource, Method.PUT);
            request.AddUrlSegment("charityId", charityId.ToString());
            request.AddUrlSegment("pageShortName", pageShortName);
            request.AddJsonBody(new CharityPageAttributionRequest(attribution));
            return await Execute(request);
        }

        public async Task<IRestResponse> CharityAppendToFundraisingPageAttribution(int charityId, string pageShortName, string attribution)
        {
            const string resource = "/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new RestRequest(resource, Method.POST);
            request.AddUrlSegment("charityId", charityId.ToString());
            request.AddUrlSegment("pageShortName", pageShortName);
            request.AddJsonBody(new CharityPageAttributionRequest(attribution));
            return await Execute(request);
        }

        public async Task<IRestResponse<CharityPageAttributionResponse>> CharityPageAttribution(int charityId, string pageShortName)
        {
            const string resource = "/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("charityId", charityId.ToString());
            request.AddUrlSegment("pageShortName", pageShortName);
            return await Execute<CharityPageAttributionResponse>(request);
        }

        public async Task<IRestResponse<List<CharityCategory>>> GetCharityCategories()
        {
            const string resource = "/v1/charity/categories";
            var request = new RestRequest(resource, Method.GET);
            return await Execute<List<CharityCategory>>(request);
        }
    }
}
