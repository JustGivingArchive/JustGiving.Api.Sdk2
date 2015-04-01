# JustGiving.Api.Sdk2

New version of the public .NET SDK for the Consumer API. 

## Improvements over the legacy SDK

- Supports authorization via OpenId Connect (OAuth2) and HTTP Basic
- Method and parameter names now match API resource URIs and the public documentation
- Built on the popular RestSharp library instead of HttpWebRequest
- Keeps developers aware of HTTP instead of ineffectively hiding it!
- Performs extended logging of HTTP interactions for easier remote troubleshooting (no more "what's a header?")
- Cleaner, easier configuration with sensible defaults
