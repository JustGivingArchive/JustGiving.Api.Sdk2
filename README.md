## JavaScript SDK features

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

