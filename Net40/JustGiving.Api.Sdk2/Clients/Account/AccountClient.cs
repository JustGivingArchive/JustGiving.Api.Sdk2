using System.Collections.Generic;
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

        public IRestResponse<AccountRegistration> AccountRegistration(Registration accountRegistration)
        {
            const string resource = "/v1/account";

            var request = new RestRequest(resource, Method.PUT);

            request.AddJsonBody(accountRegistration);

            return Execute<AccountRegistration>(request);
        }

        public IRestResponse<ValidateUser> Validate(ValidateUserRequest credentials)
        {
            const string resource = "/v1/account/validate";

            var request = new RestRequest(resource, Method.POST);

            request.AddJsonBody(credentials);

            return Execute<ValidateUser>(request);
        }

        public IRestResponse<Model.Account.Response.Account> RetrieveAccount()
        {
            const string resource = "/v1/account";

            var request = new RestRequest(resource, Method.GET);

            return Execute<Model.Account.Response.Account>(request);
        }

        public IRestResponse<List<FundraisingPage>> GetFundraisingPagesForUser(string emailAddress)
        {
            const string resource = "/v1/account/{email}/pages";

            var request = new RestRequest(resource, Method.GET);

            request.AddUrlSegment("email", emailAddress);

            return Execute<List<FundraisingPage>>(request);
        }

        public IRestResponse RequestPasswordReminder(string emailAddress)
        {
            const string resource = "/v1/account/{email}/requestpasswordreminder";

            var request = new RestRequest(resource, Method.GET);

            request.AddUrlSegment("email", emailAddress);

            return Execute(request);
        }

        public IRestResponse<GetDonationsResponse> GetDonationsForUser(int charityId, int pageNum = 0, int pageSize = 150)
        {
            const string resource = "/v1/account/donations";

            var request = new RestRequest(resource, Method.GET);

            request.AddParameter("charityId", charityId, ParameterType.QueryString);
            request.AddParameter("pageNum", pageNum, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);

            return Execute<GetDonationsResponse>(request);
        }

        public IRestResponse AccountAvailabilityCheck(string email)
        {
            const string resource = "/v1/account/{email}";

            var request = new RestRequest(resource, Method.HEAD);

            request.AddUrlSegment("email", email);

            return Execute(request);
        }

        public IRestResponse<GetUserContentRatingHistoryResponse> GetUserContentRatingHistory(int page = 0, int pageSize = 150)
        {
            const string resource = "/v1/account/rating";
            var request = new RestRequest(resource, Method.GET);

            request.AddParameter("page", page, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);

            return Execute<GetUserContentRatingHistoryResponse>(request);
        }

        public IRestResponse RateContent(RateContentRequest rating)
        {
            const string resource = "/v1/account/rating";
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(rating);

            return Execute(request);
        }
        public IRestResponse<GetContentFeedResponse> GetContentFeed()
        {
            const string resource = "/v1/account/feed";
            var request = new RestRequest(resource, Method.GET);
            return Execute<GetContentFeedResponse>(request);
        }

        public IRestResponse<List<string>> InterestsGet()
        {
            const string resource = "/v1/account/interest";
            var request = new RestRequest(resource, Method.GET);
            return Execute<List<string>>(request);
        }

        public IRestResponse InterestsAdd(string interest)
        {
            const string resource = "/v1/account/interest";
            var request = new RestRequest(resource, Method.POST);
            request.AddJsonBody(new AddInterestRequest(interest));
            return Execute(request);
        }
        public IRestResponse InterestsReplace(params string[] interests)
        {
            const string resource = "/v1/account/interest";
            var request = new RestRequest(resource, Method.PUT);
            request.AddJsonBody(new List<string>(interests));
            return Execute(request);
        }
    }
}
