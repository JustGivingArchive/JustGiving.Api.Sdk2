using System;
using JustGiving.Api.Sdk2.Configuration;
using JustGiving.Api.Sdk2.Security;
using RestSharp;

namespace JustGiving.Api.Sdk2.Http
{
    internal class RestClientFactory
    {
        public IRestClient CreateClient(ClientOptions options)
        {
            var client = new RestClient(options.Endpoint);

            switch (options.AuthorizationMode)
            {
                case AuthorizationMode.OAuth:
                    if (options.OAuthAccessToken == null)
                    {
                        throw new InvalidOperationException("Client is configured for OAuth authorization but no access token has been provided");
                    }

                    client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(options.OAuthAccessToken.Value);
                    break;
                case AuthorizationMode.Basic:
                    if (options.BasicAuthSettings == null)
                    {
                        throw new InvalidOperationException("Client is configured for Basic authentication but no user credential has been provided");
                    }

                    client.Authenticator = new HttpBasicAuthenticator(options.BasicAuthSettings.Username, options.BasicAuthSettings.Password);
                    break;
            }

            if (!string.IsNullOrWhiteSpace(options.ApplicationKey))
            {
                client.AddDefaultHeader("x-application-key", options.ApplicationKey);
            }

            client.AddDefaultHeader("x-app-id", options.AppId);
            client.AddDefaultHeader("x-justgiving-sdk-version", options.SdkVersion);

            if (options.RequestDebuggingInfo)
            {
                client.AddDefaultParameter("debug", "true", ParameterType.QueryString);
            }

            return client;
        }
    }
}
