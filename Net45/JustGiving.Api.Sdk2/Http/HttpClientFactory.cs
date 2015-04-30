using System;
using System.Net.Http;
using System.Net.Http.Headers;
using JustGiving.Api.Sdk2.Configuration;
using JustGiving.Api.Sdk2.Security;

namespace JustGiving.Api.Sdk2.Http
{
    /// <summary>
    /// For making raw HTTP requests e.g. uploading images
    /// </summary>
    internal class HttpClientFactory
    {
        public HttpClient CreateClient(ClientOptions options)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(options.Endpoint)
            };


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            switch (options.AuthorizationMode)
            {
                case AuthorizationMode.OAuth:
                    if (options.OAuthAccessToken == null)
                    {
                        throw new InvalidOperationException("Client is configured for OAuth authorization but no access token has been provided");
                    }

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.OAuthAccessToken.Value);
                    
                    break;
                case AuthorizationMode.Basic:
                    if (options.BasicAuthSettings == null)
                    {
                        throw new InvalidOperationException("Client is configured for Basic authentication but no user credential has been provided");
                    }

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", options.BasicAuthSettings.Base64Encode());
                    break;
            }

            if (!string.IsNullOrWhiteSpace(options.ApplicationKey))
            {
                client.DefaultRequestHeaders.Add("x-application-key", options.ApplicationKey);
            }

            client.DefaultRequestHeaders.Add("x-app-id", options.AppId);
            client.DefaultRequestHeaders.Add("x-justgiving-sdk-version", options.SdkVersion);

            return client;
        }
    }
}