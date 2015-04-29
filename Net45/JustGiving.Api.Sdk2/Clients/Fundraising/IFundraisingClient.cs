using System.Collections.Generic;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Model.Fundraising.Request;
using JustGiving.Api.Sdk2.Model.Fundraising.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Fundraising
{
    public interface IFundraisingClient
    {
        Task<IRestResponse> FundraisingPageUrlCheck(string pageShortName);
        Task<IRestResponse<SuggestedNames>> SuggestPageShortNames(string preferredName);
        Task<IRestResponse<FundraisingPageRegistrationResponse>> RegisterFundraisingPage(FundraisingPageRegistration pageRegistration);
        Task<IRestResponse<FundraisingPageDetails>> GetFundraisingPageDetails(string pageShortName);
        Task<IRestResponse<List<FundraisingPageDetails>>> GetFundraisingPages();
        Task<IRestResponse<FundraisingPageDonations>> GetFundraisingPageDonations(string pageShortName);
        Task<IRestResponse<FundraisingPageDonations>> GetFundraisingPageDonationsByReference(string pageShortName, string reference);
        Task<IRestResponse> UpdateFundraisingPage(string pageShortName, Model.Fundraising.Request.FundraisingPageUpdate update);
        Task<IRestResponse<List<Model.Fundraising.Response.MicroblogUpdate>>> PageUpdates(string pageShortName);
        Task<IRestResponse<RestResponseNavigationElement>> PageUpdatesAddPost(string pageShortName, Model.Fundraising.Request.MicroblogUpdate update);
        Task<IRestResponse<Model.Fundraising.Response.MicroblogUpdate>> PageUpdateById(string pageShortName, int postId);
    }
}