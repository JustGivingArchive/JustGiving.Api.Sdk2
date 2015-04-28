using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Model.Event.Request;
using JustGiving.Api.Sdk2.Model.Event.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Event
{
    public interface IEventClient
    {
        Task<IRestResponse<Model.Event.Response.Event>> GetEventById(int id);
        Task<IRestResponse<PagesForEvent>> GetPagesForEvent(int eventId, int page = 1, int pageSize = 100);
        Task<IRestResponse<EventRegistrationResponse>> RegisterEvent(EventRegistration eventRegistration);
    }
}