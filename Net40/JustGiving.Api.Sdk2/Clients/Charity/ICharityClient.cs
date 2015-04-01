using System.Collections.Generic;
using JustGiving.Api.Sdk2.Model.Charity.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Charity
{
    public interface ICharityClient
    {
        IRestResponse<Model.Charity.Response.Charity> GetCharityById(int charityId);
        IRestResponse<GetEventsByCharityIdResponse> GetEventsByCharityId(int charityId, int pageNum = 0, int pageSize = 150);
        IRestResponse<List<Donation>> GetCharityDonations(int charityId);
        IRestResponse CharityDeleteFundraisingPageAttribution(int charityId, string pageShortName);
        IRestResponse CharityUpdateFundraisingPageAttribution(int charityId, string pageShortName, string attribution);
        IRestResponse CharityAppendToFundraisingPageAttribution(int charityId, string pageShortName, string attribution);
        IRestResponse<CharityPageAttributionResponse> CharityPageAttribution(int charityId, string pageShortName);
        IRestResponse<List<CharityCategory>> GetCharityCategories();
    }
}