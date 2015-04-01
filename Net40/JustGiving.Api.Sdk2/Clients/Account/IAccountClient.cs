using System.Collections.Generic;
using JustGiving.Api.Sdk2.Model.Account.Request;
using JustGiving.Api.Sdk2.Model.Account.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Account
{
    public interface IAccountClient
    {
        IRestResponse<AccountRegistration> AccountRegistration(Registration accountRegistration);
        IRestResponse<ValidateUser> Validate(ValidateUserRequest credentials);
        IRestResponse<Model.Account.Response.Account> RetrieveAccount();
        IRestResponse<List<FundraisingPage>> GetFundraisingPagesForUser(string emailAddress);
        IRestResponse RequestPasswordReminder(string emailAddress);
        IRestResponse<GetDonationsResponse> GetDonationsForUser(int charityId, int pageNum = 0, int pageSize = 150);
        IRestResponse AccountAvailabilityCheck(string email);
        IRestResponse<GetUserContentRatingHistoryResponse> GetUserContentRatingHistory(int page = 0, int pageSize = 150);
        IRestResponse RateContent(RateContentRequest request);
        IRestResponse<GetContentFeedResponse> GetContentFeed();
        IRestResponse<List<string>> InterestsGet();
        IRestResponse InterestsAdd(string interest);
        IRestResponse InterestsReplace(params string[] interests);
    }
}