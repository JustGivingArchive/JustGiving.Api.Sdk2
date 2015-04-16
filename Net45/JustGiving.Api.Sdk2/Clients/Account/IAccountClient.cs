using System.Collections.Generic;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Model.Account.Request;
using JustGiving.Api.Sdk2.Model.Account.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Account
{
    public interface IAccountClient
    {
        Task<IRestResponse<AccountRegistration>> AccountRegistration(Registration accountRegistration);
        Task<IRestResponse<ValidateUser>> Validate(ValidateUserRequest credentials);
        Task<IRestResponse<Model.Account.Response.Account>> RetrieveAccount();
        Task<IRestResponse<List<FundraisingPage>>> GetFundraisingPagesForUser(string emailAddress);
        Task<IRestResponse> RequestPasswordReminder(string emailAddress);
        Task<IRestResponse<GetDonationsResponse>> GetDonationsForUser(int charityId, int pageNum = 0, int pageSize = 150);
        Task<IRestResponse> AccountAvailabilityCheck(string email);
        Task<IRestResponse<GetUserContentRatingHistoryResponse>> GetUserContentRatingHistory(int page = 0, int pageSize = 150);
        Task<IRestResponse> RateContent(RateContentRequest request);
        Task<IRestResponse<GetContentFeedResponse>> GetContentFeed();
        Task<IRestResponse<List<string>>> InterestsGet();
        Task<IRestResponse> InterestsAdd(string interest);
        Task<IRestResponse> InterestsReplace(params string[] interests);
    }
}