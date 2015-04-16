using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Countries
{
    public interface ICountryClient
    {
        Task<IRestResponse<List<Model.Countries.Response.Country>>> ListCountries();
    }
}