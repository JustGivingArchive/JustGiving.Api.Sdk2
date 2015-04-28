using System;
using System.Net;
using System.Threading.Tasks;
using JustGiving.Api.Sdk2.Security.Basic;
using JustGiving.Api.Sdk2.Test.Integration.Account;

namespace JustGiving.Api.Sdk2.Test.Integration
{
    public class TestContext
    {
        private const string AppId = "6c37285f";
        public static JustGivingApiClient2 CreateAnonymousClient()
        {
            var client = new JustGivingApiClient2(AppId);
            client.UseSandbox();
            client.LogEverything();
            return client;
        }

        public static JustGivingApiClient2 CreateBasicAuthClient(string username, string password)
        {
            var client = new JustGivingApiClient2(AppId, new BasicCredential(username, password));
            client.UseSandbox();
            client.LogEverything();
   
            return client;
        }

        public static async Task<JustGivingApiClient2> CreateBasicAuthClientAndUser()
        {
            string username;
            string password;
            var registration = AccountHelper.CreateRegistration(out username, out password);
            var client = CreateAnonymousClient();
            var response = await client.Accounts.AccountRegistration(registration);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Could not create a remote user account");
            }

            return CreateBasicAuthClient(username, password);
        }

        public const int DemoCharityId = 2050;
        public const string DemoCharityFundraisingPageId = "trocboxtest4";
    }
}
