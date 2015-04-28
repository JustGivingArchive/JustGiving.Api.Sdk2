using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Event.Request;
using JustGiving.Api.Sdk2.Model.Event.Response;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Event
{
    public class EventClient : ClientBase, IEventClient
    {
        internal EventClient(IRestClient client, ApiRequestLogger logger) : base(client, logger)
        {
        }

        public async Task<IRestResponse<Model.Event.Response.Event>> GetEventById(int id)
        {
            const string resource = "/v1/event/{id}";
            var request = new Http.RestRequest(resource, Method.GET);
            request.AddUrlSegment("id", id.ToString());
            return await Execute<Model.Event.Response.Event>(request);
        }

        public async Task<IRestResponse<PagesForEvent>> GetPagesForEvent(int eventId, int page = 1, int pageSize = 100)
        {
            const string resource = "/v1/event/{id}/pages";
            var request = new Http.RestRequest(resource, Method.GET);
            request.AddUrlSegment("id", eventId.ToString());
            request.AddQueryParameter("page", page.ToString());
            request.AddQueryParameter("pageSize", pageSize.ToString());
            return await Execute<PagesForEvent>(request);
        }

        public async Task<IRestResponse<EventRegistrationResponse>> RegisterEvent(EventRegistration eventRegistration)
        {
            const string resource = "/v1/event";

            var request = new Http.RestRequest(resource, Method.POST);

            request.AddJsonBody(eventRegistration);

            return await Execute<EventRegistrationResponse>(request);
        }
    }
}
