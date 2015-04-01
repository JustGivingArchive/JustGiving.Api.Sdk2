using System;
using System.Configuration;
using JustGiving.Api.Sdk2.Configuration;
using RestSharp;

namespace JustGiving.Api.Sdk2.Logging
{
    internal class ApiRequestLogger
    {
        private readonly ILogProvider _log;

        private readonly ClientOptions _options;
        public ApiRequestLogger(ClientOptions options, ILogProvider log)
        {
            _options = options;
            _log = log;
        }

        /// <summary>
        /// Every time the SDK communicates with the API (or tries to), we can generate a nice log entry to show us exactly what happened and why. 
        /// Depending on the configuration options, this might log all requests, or just the ones which fail. The level of detail can also be
        /// configured depending on different development / production scenarios and PCI considerations.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void LogRequest(IRestRequest request, IRestResponse response)
        {
            bool success = false;
            bool serverError = false;

            if (response != null)
            {
                success = (int)response.StatusCode < 400 && (int)response.StatusCode > 0;
                serverError = (int)response.StatusCode >= 500;
            }

            if ((_options.LoggingOptions.LogSuccessfulRequests && success) || LogEverythingAppSettingOverride)
            {
                var message = FormatLogMessage(request, response);
                _log.Info(message);
            }
            else if ((_options.LoggingOptions.LogFailedRequests && !success) || LogEverythingAppSettingOverride)
            {
                var message = FormatLogMessage(request, response);

                if (serverError)
                {
                    _log.Error(message);
                }
                else
                {
                    _log.Warn(message);
                }
            }
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            _log.Error(message, exception);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        /// <summary>
        /// Creates a log entry based on the HTTP request and response, with a level of detail appropriate to what has been set via configuration options.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        private string FormatLogMessage(IRestRequest request, IRestResponse response)
        {
            var message = FormatRequestLogMessage(request);

            if (_options.LoggingOptions.LogAllMessageContent || LogEverythingAppSettingOverride)
            {
                message += FormatExtendedRequestLogMessage(request);
            }

            message += FormatResponseLogMessage(response);

            if (_options.LoggingOptions.LogAllMessageContent || LogEverythingAppSettingOverride)
            {
                message += FormatExtendedResponseLogMessage(response);
            }

            return message;
        }

        /// <summary>
        /// Logs HTTP status code only. Will not log sensitive data.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string FormatResponseLogMessage(IRestResponse response)
        {
            var message = string.Empty;

            if (response == null)
            {
                message += "\r\n[HttpResponse] No response\r\n";
                return message;
            }

            message += "\r\n[HttpResponse]";
            message += string.Format("\r\n[HttpStatus] {0} {1}\r\n", (int)response.StatusCode, response.StatusDescription);

            return message;
        }

        /// <summary>
        /// Logs complete response headers and message content. Log entries will potentially contain sensitive data.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string FormatExtendedResponseLogMessage(IRestResponse response)
        {
            string message = string.Empty;
            if (response == null)
            {
                return message;
            }

            foreach (var header in response.Headers)
            {
                message += string.Format("[HttpHeader] {0}: {1}\r\n", header.Name, header.Value);
            }

            if (!string.IsNullOrWhiteSpace(response.Content))
            {
                message += "[ResponseBody] ";
                message += response.Content;
                message += "\r\n";
            }

            return message;
        }

        /// <summary>
        /// Logs the request URI and information to help identify the client. Does not log sensitive data.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string FormatRequestLogMessage(IRestRequest request)
        {
            var message = "\r\n[HttpRequest] ";
            message += string.Format("{0} {1}{2}\r\n", request.Method, _options.Endpoint, request.Resource);
            message += "[AuthorizationMode] " + _options.AuthorizationMode + "\r\n";
            message += "[AppId] " + _options.AppId + "\r\n";
            message += "[ApplicationKey?] " + (string.IsNullOrWhiteSpace(_options.ApplicationKey) ? "No\r\n" : "Yes\r\n");

            return message;
        }
        /// <summary>
        /// Logs all request headers and the message body. Log entries will potentially contain sensitive data.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static string FormatExtendedRequestLogMessage(IRestRequest request)
        {
            var message = string.Empty;
            foreach (var p in request.Parameters)
            {
                message += string.Format("[{0}] {1}: {2}\r\n", p.Type, p.Name, p.Value);
            }

            return message;
        }

        private static bool LogEverythingAppSettingOverride
        {
            get
            {
                // config setting always overrides what's in the code
                var appSetting = ConfigurationManager.AppSettings["JustGiving.LogEverything"];

                if (string.IsNullOrWhiteSpace(appSetting))
                {
                    return false;
                }

                return string.Equals(appSetting, "true", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
