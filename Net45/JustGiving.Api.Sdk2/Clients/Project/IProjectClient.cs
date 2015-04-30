using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Model.Project;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Project
{
    public interface IProjectClient
    {
        Task<IRestResponse<GlobalProject>> GlobalProjectById(int projectId);
    }
}