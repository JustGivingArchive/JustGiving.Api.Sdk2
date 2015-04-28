using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Donation.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Donation
{
    public class DonationClient : ClientBase, IDonationClient
    {
        internal DonationClient(IRestClient client, ApiRequestLogger logger) : base(client, logger)
        {
        }

        public async Task<IRestResponse<DonationsByReference>> RetrieveDonationDetailsByReference(string thirdPartyReference, int pageNum = 1, int pageSize = 100)
        {
            const string resource = "/v1/donation/ref/{ref}";
            var request = new Http.RestRequest(resource, Method.GET);
            request.AddUrlSegment("ref", thirdPartyReference);
            request.AddQueryParameter("pageNum", pageNum.ToString());
            request.AddQueryParameter("pageSize", pageSize.ToString());
            return await Execute<DonationsByReference>(request);
        }

        public async Task<IRestResponse<Model.Donation.Response.Donation>> RetrieveDonationDetails(int donationId)
        {
            const string resource = "/v1/donation/{id}";
            var request = new Http.RestRequest(resource, Method.GET);
            request.AddUrlSegment("id", donationId.ToString());
            return await Execute<Model.Donation.Response.Donation>(request);
        }

        public async Task<IRestResponse<DonationStatus>> RetrieveDonationStatus(int donationId)
        {
            const string resource = "/v1/donation/{id}/status";
            var request = new Http.RestRequest(resource, Method.GET);
            request.AddUrlSegment("id", donationId.ToString());
            return await Execute<DonationStatus>(request);
        }
    }
}
