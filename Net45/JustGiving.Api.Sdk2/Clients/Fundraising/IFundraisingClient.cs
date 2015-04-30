using System.Collections.Generic;
using System.Net.Http;
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
        Task<IRestResponse> DeleteFundraisingPageUpdate(string pageShortName, int postId);
        Task<IRestResponse> AppendToFundraisingPageAttribution(string pageShortName, Model.Fundraising.Request.FundraisingPageAttribution attribution);
        Task<IRestResponse> UpdateFundraisingPageAttribution(string pageShortName, Model.Fundraising.Request.FundraisingPageAttribution attribution);
        Task<IRestResponse<Model.Fundraising.Response.FundraisingPageAttribution>> GetFundraisingPageAttribution(string pageShortName);
        Task<IRestResponse> DeleteFundraisingPageAttribution(string pageShortName);
        Task<HttpResponseMessage> UploadImage(string pageShortName, byte[] imageData, string contentType, string caption = "");
        Task<HttpResponseMessage> UploadDefaultImage(string pageShortName, byte[] imageData, string contentType, string caption = "");
        Task<IRestResponse<AddImageToFundraisingPageResponse>> AddImageToFundraisingPage(string pageShortName, ImageInfo image);
        Task<IRestResponse> DeleteFundraisingPageImage(string pageShortName, string imageFileName, bool isStockImage);
        Task<IRestResponse<List<FundraisingPageImage>>> GetImagesForFundraisingPage(string pageShortName);
        Task<IRestResponse<AddVideoToFundraisingPageResponse>> AddVideoToFundraisingPage(string pageShortName, VideoInfo video);
        Task<IRestResponse<List<FundraisingPageVideo>>> GetVideosForFundraisingPage(string pageShortName);
        Task<IRestResponse> CancelFundraisingPage(string pageShortName);
        Task<IRestResponse> UpdateNotificationsPreferences(string pageShortName, NotificationPreferences preferences);
        Task<IRestResponse> UpdateFundraisingPageSummary(string pageName, FundraisingPageSummary summary);
    }
}