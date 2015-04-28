using System.Collections.Generic;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Model.Charity.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Charity
{
    public interface ICharityClient
    {
        Task<IRestResponse<Model.Charity.Response.Charity>> GetCharityById(int charityId);
        Task<IRestResponse<GetEventsByCharityIdResponse>> GetEventsByCharityId(int charityId, int pageNum = 0, int pageSize = 150);
        Task<IRestResponse<CharityDonations>> GetCharityDonations(int charityId);
        Task<IRestResponse> CharityDeleteFundraisingPageAttribution(int charityId, string pageShortName);
        Task<IRestResponse> CharityUpdateFundraisingPageAttribution(int charityId, string pageShortName, string attribution);
        Task<IRestResponse> CharityAppendToFundraisingPageAttribution(int charityId, string pageShortName, string attribution);
        Task<IRestResponse<CharityPageAttributionResponse>> CharityPageAttribution(int charityId, string pageShortName);
        Task<IRestResponse<List<CharityCategory>>> GetCharityCategories();
    }
}