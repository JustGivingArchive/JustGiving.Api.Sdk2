using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace JustGiving.Api.Sdk2.Clients.Currency
{
    public interface ICurrencyClient
    {
        Task<IRestResponse<List<Model.Currency.Response.Currency>>> GetValidCurrencyCodes();
    }
}