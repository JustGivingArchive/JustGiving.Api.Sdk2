using System.Collections.Generic;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Countries
{
    public interface ICountryClient
    {
        IRestResponse<List<Model.Countries.Response.Country>> ListCountries();
    }
}