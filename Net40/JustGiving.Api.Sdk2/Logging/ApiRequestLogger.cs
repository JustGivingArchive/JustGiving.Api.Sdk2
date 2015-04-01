using System;
using System.Configuration;
using JustGiving.Api.Sdk2.Configuration;
using RestSharp;

namespace JustGiving.Api.Sdk2.Logging
{
    internal class ApiRequestLogger
    {
        private readonly ILogProvider _log;
        private bool _logEverything;

        private readonly ClientOptions _options;
        public ApiRequestLogger(ClientOptions options, ILogProvider log)
        {
            _options = options;
            _log = log;
            _logEverything = _options.LoggingOptions.LogAllMessageContent ||
                             ConfigurationManager.AppSettings["JustGiving.LogEverything"] == "true";
        }

        public void LogEverything()
        {
            _logEverything = true;
        }

        private string FormatLogMessage(IRestRequest request, IRestResponse response)
        {
            var message = "\r\n[HttpRequest] ";
            message += string.Format("{0} {1}{2}\r\n", request.Method, _options.Endpoint, request.Resource);
            message += "[AuthorizationMode] " + _options.AuthorizationMode + "\r\n";
            message += "[AppId] " + _options.AppId + "\r\n";
            message += "[ApplicationKey?] " + (string.IsNullOrWhiteSpace(_options.ApplicationKey) ? "No\r\n" : "Yes\r\n");

            if (_logEverything)
            {
                foreach (var p in request.Parameters)
                {
                    message += string.Format("[{0}] {1}: {2}\r\n", p.Type, p.Name, p.Value);
                }
            }

            if (response == null)
            {
                return message;
            }

            message += "\r\n[HttpResponse]";
            message += string.Format("\r\n[HttpStatus] {0} {1}\r\n", (int) response.StatusCode, response.StatusDescription);

            if (_logEverything)
            {
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
            }

           
            return message;
        }

        public void LogRequest(IRestRequest request, IRestResponse response)
        {
            bool success = false;
            bool serverError = false;

            if (response != null)
            {
                success = (int) response.StatusCode < 300 && (int) response.StatusCode > 0;
                serverError = (int) response.StatusCode >= 500;
            }

            if ((_options.LoggingOptions.LogSuccessfulRequests && success) || _logEverything)
            {
                var message = FormatLogMessage(request, response);
                _log.Info(message);
            }
            else if((_options.LoggingOptions.LogFailedRequests && !success) || _logEverything)
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
    }
}
