using System;
using System.Collections.Generic;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Charity.Request;
using JustGiving.Api.Sdk2.Model.Charity.Response;
using RestSharp;
using RestRequest = JustGiving.Api.Sdk2.Http.RestRequest;

namespace JustGiving.Api.Sdk2.Clients.Charity
{
    public class CharityClient : ClientBase, ICharityClient
    {
        internal CharityClient(IRestClient client, ApiRequestLogger logger) : base(client, logger)
        {
        }

        public IRestResponse<Model.Charity.Response.Charity> GetCharityById(int charityId)
        {
            const string resource = "/v1/charity/{charityId}";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("charityId", charityId.ToString());
            return Execute<Model.Charity.Response.Charity>(request);
        }

        public IRestResponse<GetEventsByCharityIdResponse> GetEventsByCharityId(int charityId, int pageNum = 0, int pageSize = 150)
        {
            const string resource = "/v1/charity/{charityId}/events";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("charityId", charityId.ToString());
            return Execute<GetEventsByCharityIdResponse>(request);
        }

        public IRestResponse<List<Donation>> GetCharityDonations(int charityId)
        {
            const string resource = "/v1/charity/{charityId}/donations";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("charityId", charityId.ToString());
            return Execute<List<Donation>>(request);
        }
        public IRestResponse CharityDeleteFundraisingPageAttribution(int charityId, string pageShortName)
        {
            const string resource = "/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new RestRequest(resource, Method.DELETE);
            request.AddUrlSegment("charityId", charityId.ToString());
            request.AddUrlSegment("pageShortName", pageShortName);
            return Execute(request);
        }

        public IRestResponse CharityUpdateFundraisingPageAttribution(int charityId, string pageShortName, string attribution)
        {
            const string resource = "/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new RestRequest(resource, Method.PUT);
            request.AddUrlSegment("charityId", charityId.ToString());
            request.AddUrlSegment("pageShortName", pageShortName);
            request.AddJsonBody(new CharityPageAttributionRequest(attribution));
            return Execute(request);
        }

        public IRestResponse CharityAppendToFundraisingPageAttribution(int charityId, string pageShortName, string attribution)
        {
            const string resource = "/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new RestRequest(resource, Method.POST);
            request.AddUrlSegment("charityId", charityId.ToString());
            request.AddUrlSegment("pageShortName", pageShortName);
            request.AddJsonBody(new CharityPageAttributionRequest(attribution));
            return Execute(request);
        }

        public IRestResponse<CharityPageAttributionResponse> CharityPageAttribution(int charityId, string pageShortName)
        {
            const string resource = "/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("charityId", charityId.ToString());
            request.AddUrlSegment("pageShortName", pageShortName);
            return Execute<CharityPageAttributionResponse>(request);
        }

        public IRestResponse<List<CharityCategory>> GetCharityCategories()
        {
            const string resource = "/v1/charity/categories";
            var request = new RestRequest(resource, Method.GET);
            return Execute<List<CharityCategory>>(request);
        }
    }
}
