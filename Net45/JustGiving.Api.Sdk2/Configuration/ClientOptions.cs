using System.Reflection;
using JustGiving.Api.Sdk2.Configuration.Logging;
using JustGiving.Api.Sdk2.Http;
using JustGiving.Api.Sdk2.Security;
using JustGiving.Api.Sdk2.Security.Basic;
using JustGiving.Api.Sdk2.Security.OAuth;

namespace JustGiving.Api.Sdk2.Configuration
{
    public class ClientOptions
    {
        private readonly string _appId;

        private readonly string _applicationKey;

        private string _sdkVersion;

        public ClientOptions(string appId)
        {
            _appId = appId;
            LoggingOptions = LoggingOptions.Default;
            Endpoint = Endpoints.Production;
        }

        public ClientOptions(string appId, string applicationKey)
        {
            _appId = appId;
            _applicationKey = applicationKey;
            LoggingOptions = LoggingOptions.Default;
            Endpoint = Endpoints.Production;
        }

        public string AppId
        {
            get { return _appId; }
        }

        public string Endpoint { get; set; }

        public OAuthAccessToken OAuthAccessToken { get; set; }

        public BasicCredential BasicAuthSettings { get; set; }

        public AuthorizationMode AuthorizationMode { get; set; }
        /// <summary>
        /// If enabled, all requests to the API will include ?debug=true as a query string parameter, which asks the server to include extended debugging information in any error responses.
        /// </summary>
        public bool RequestDebuggingInfo { get; set; }

        public string ApplicationKey
        {
            get { return _applicationKey; }
        }

        public LoggingOptions LoggingOptions { get; set; }

        public string SdkVersion
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_sdkVersion))
                {
                    _sdkVersion =
                        Assembly.GetAssembly(GetType()).GetName().Version.ToString();
                }

                return _sdkVersion;
            }
        }
    }
}