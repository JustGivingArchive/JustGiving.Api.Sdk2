using System.Collections.Generic;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Fundraising.Request;
using JustGiving.Api.Sdk2.Model.Fundraising.Response;
using RestRequest = JustGiving.Api.Sdk2.Http.RestRequest;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Fundraising
{
    public class FundraisingClient : ClientBase, IFundraisingClient
    {
        internal FundraisingClient(IRestClient client, ApiRequestLogger logger) : base(client, logger)
        {
        }

        public async Task<IRestResponse> FundraisingPageUrlCheck(string pageShortName)
        {
            const string resource = "/v1/fundraising/pages/{pageShortName}";
            var request = new RestRequest(resource, Method.HEAD);
            request.AddUrlSegment("pageShortName", pageShortName);
            var response = await Execute(request);
            return response;
        }

        public async Task<IRestResponse<SuggestedNames>> SuggestPageShortNames(string preferredName)
        {
            const string resource = "/v1/fundraising/pages/suggest";
            var request = new RestRequest(resource, Method.GET);
            request.AddQueryParameter("preferredName", preferredName);
            return await Execute<SuggestedNames>(request);
        }

        public async Task<IRestResponse<FundraisingPageRegistrationResponse>> RegisterFundraisingPage(FundraisingPageRegistration pageRegistration)
        {
            const string resource = "/v1/fundraising/pages";
            var request = new RestRequest(resource, Method.PUT);
            request.AddJsonBody(pageRegistration);
            return await Execute<FundraisingPageRegistrationResponse>(request);
        }

        public async Task<IRestResponse<FundraisingPageDetails>> GetFundraisingPageDetails(string pageShortName)
        {
            const string resource = "/v1/fundraising/pages/{pageShortName}";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("pageShortName", pageShortName);
            var response = await Execute <FundraisingPageDetails>(request);
            return response;
        }

        public async Task<IRestResponse<List<FundraisingPageDetails>>> GetFundraisingPages()
        {
            const string resource = "/v1/fundraising/pages";
            var request = new RestRequest(resource, Method.GET);
            var response = await Execute<List<FundraisingPageDetails>>(request);
            return response;
        }

        public async Task<IRestResponse<FundraisingPageDonations>> GetFundraisingPageDonations(string pageShortName)
        {
            const string resource = "/v1/fundraising/pages/{pageShortName}/donations";
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("pageShortName", pageShortName);
            var response = await Execute<FundraisingPageDonations>(request);
            return response;
        }
    }
}
