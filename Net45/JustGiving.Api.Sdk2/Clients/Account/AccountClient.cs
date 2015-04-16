using System.Collections.Generic;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Account.Request;
using JustGiving.Api.Sdk2.Model.Account.Response;
using RestSharp;
using RestRequest = JustGiving.Api.Sdk2.Http.RestRequest;

namespace JustGiving.Api.Sdk2.Clients.Account
{
    public class AccountClient : ClientBase, IAccountClient
    {
        internal AccountClient(IRestClient client, ApiRequestLogger logger)
            : base(client, logger)
        {
        }

        public async Task<IRestResponse<AccountRegistration>> AccountRegistration(Registration accountRegistration)
        {
            const string resource = "/v1/account";

            var request = new RestRequest(resource, Method.PUT);

            request.AddJsonBody(accountRegistration);

            return await Execute<AccountRegistration>(request);
        }

        public async Task<IRestResponse<ValidateUser>> Validate(ValidateUserRequest credentials)
        {
            const string resource = "/v1/account/validate";

            var request = new RestRequest(resource, Method.POST);

            request.AddJsonBody(credentials);

            return await Execute<ValidateUser>(request);
        }

        public async Task<IRestResponse<Model.Account.Response.Account>> RetrieveAccount()
        {
            const string resource = "/v1/account";

            var request = new RestRequest(resource, Method.GET);

            return await Execute<Model.Account.Response.Account>(request);
        }

        public async Task<IRestResponse<List<FundraisingPage>>> GetFundraisingPagesForUser(string emailAddress)
        {
            const string resource = "/v1/account/{email}/pages";

            var request = new RestRequest(resource, Method.GET);

            request.AddUrlSegment("email", emailAddress);

            return await Execute<List<FundraisingPage>>(request);
        }

        public async Task<IRestResponse> RequestPasswordReminder(string emailAddress)
        {
            const string resource = "/v1/account/{email}/requestpasswordreminder";

            var request = new RestRequest(resource, Method.GET);

            request.AddUrlSegment("email", emailAddress);

            return await Execute(request);
        }

        public async Task<IRestResponse<GetDonationsResponse>> GetDonationsForUser(int charityId, int pageNum = 0, int pageSize = 150)
        {
            const string resource = "/v1/account/donations";

            var request = new RestRequest(resource, Method.GET);

            request.AddParameter("charityId", charityId, ParameterType.QueryString);
            request.AddParameter("pageNum", pageNum, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);

            return await Execute<GetDonationsResponse>(request);
        }

        public async Task<IRestResponse> AccountAvailabilityCheck(string email)
        {
            const string resource = "/v1/account/{email}";

            var request = new RestRequest(resource, Method.HEAD);

            request.AddUrlSegment("email", email);

            return await Execute(request);
        }

        public async Task<IRestResponse<GetUserContentRatingHistoryResponse>> GetUserContentRatingHistory(int page = 0, int pageSize = 150)
        {
            const string resource = "/v1/account/rating";
            var request = new RestRequest(resource, Method.GET);

            request.AddParameter("page", page, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);

            return await Execute<GetUserContentRatingHistoryResponse>(request);
        }

        public async Task<IRestResponse> RateContent(RateContentRequest rating)
        {
            const string resource = "/v1/account/rating";
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(rating);

            return await Execute(request);
        }
        public async Task<IRestResponse<GetContentFeedResponse>> GetContentFeed()
        {
            const string resource = "/v1/account/feed";
            var request = new RestRequest(resource, Method.GET);
            return await Execute<GetContentFeedResponse>(request);
        }

        public async Task<IRestResponse<List<string>>> InterestsGet()
        {
            const string resource = "/v1/account/interest";
            var request = new RestRequest(resource, Method.GET);
            return await Execute<List<string>>(request);
        }

        public async Task<IRestResponse> InterestsAdd(string interest)
        {
            const string resource = "/v1/account/interest";
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(new AddInterestRequest(interest));
            return await Execute(request);
        }
        public async Task<IRestResponse> InterestsReplace(params string[] interests)
        {
            const string resource = "/v1/account/interest";
            var request = new RestRequest(resource, Method.PUT);
            request.AddJsonBody(new List<string>(interests));
            return await Execute(request);
        }
    }
}
