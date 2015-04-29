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
    }
}