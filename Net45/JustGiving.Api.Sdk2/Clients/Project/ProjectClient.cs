using System.Net.Http;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Logging;
using JustGiving.Api.Sdk2.Model.Project;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Project
{
    public class ProjectClient : ClientBase, IProjectClient
    {
        internal ProjectClient(IRestClient restClient, HttpClient httpClient, ApiRequestLogger logger) : base(restClient, httpClient, logger)
        {
        }

        public async Task<IRestResponse<GlobalProject>> GlobalProjectById(int projectId)
        {
            const string resource = "/v1/project/global/{projectId}";
            var request = new Http.RestRequest(resource, Method.GET);
            request.AddUrlSegment("projectId", projectId.ToString());
            var result = await Execute<GlobalProject>(request);
            return result;
        }
    }
}
