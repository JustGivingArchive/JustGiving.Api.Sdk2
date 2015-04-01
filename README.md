# JustGiving.Api.Sdk2

New version of the public .NET SDK for the Consumer API. 

## Improvements over the old SDK

- Supports authorization via OpenId Connect (OAuth2) and HTTP Basic
- Consistent method and parameter names: they now match API resource URIs and the public documentation
- Built on the popular RestSharp library instead of HttpWebRequest
- Keeps developers aware of HTTP instead of ineffectively hiding it!
- Performs extended logging of HTTP interactions for easier remote troubleshooting (no more "what's a header?")
- Cleaner, easier configuration with sensible defaults
- JSON only, no XML
- Removed support for whitelabel domains / RFL / API "versions" which don't exist
- Less code, less clutter, less maintainence
