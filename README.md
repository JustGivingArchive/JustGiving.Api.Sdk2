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

### Example:

```
var client = new JustGivingApiClient2("bafff466", new OAuthAccessToken("sdfijojweoimicew0932dnmosdf")); 
client.UseSandbox();
client.LogEverything();

var myContentFeed = client.Accounts.GetContentFeed();

if(myContentFeed.StatusCode == HttpStatusCode.Ok)
{
  return View("ContentFeed", myContentFeed.Data);
}
```

## JavaScript API features

- Extremely low barrier to entry - connect to the JG platform in two lines of HTML
- New "Connect with JustGiving" button allows JG users to sign in to external apps via OAuth2 and OpenId Connect
- Easy client-side access to Consumer API resources such as Fundraising Page creation and personalised content feeds

### Example:

```
<script src="JG.js"></script>
<jg-login onlogin="handleLoginState" />

<script>
        JG.init({
            appId: 'bafff466',
            environment: 'sandbox'
        });
        
        function handleLoginState(result){
          if(result){
            alert('Hi, ' + result.displayName);
            
            var feed = JG.getFeed();
            // ...do something with the content feed
          }
        }
</script>
```

