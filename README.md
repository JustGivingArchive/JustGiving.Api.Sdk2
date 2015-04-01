# JustGiving.Api.Sdk2

New public SDKs for the Consumer API for Microsoft .NET and JavaScript


## Improvements over the old .NET SDK

- Supports authorization via OpenId Connect (OAuth2) and HTTP Basic
- Consistent method and parameter names: they now match API resource URIs and the public documentation
- Built on the popular RestSharp library instead of HttpWebRequest
- Keeps developers aware of HTTP instead of ineffectively hiding it!
- Performs extended logging of HTTP interactions for easier remote troubleshooting (no more "what's a header?")
- Cleaner, easier configuration with sensible defaults
- JSON only, no XML
- Removed support for whitelabel domains / RFL / API "versions" which don't exist
- Less code, less clutter, less maintainence

## JavaScript API features

- Extremely low barrier to entry
- New "Connect with JustGiving" button allows third parties to hook into our platform via OAuth2 and OpenId Connect
- Easy client-side access to Consumer API resources such as Fundraising Page creation, and user content feeds
