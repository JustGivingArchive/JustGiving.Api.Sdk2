var JG = (function () {

    var _appId, _scope, _environment, _apiEndpoint, _authorizationEndpoint, _accessToken;

    var init = function (options) {
        JG.CustomElements.register();
        _appId = options.appId;
        _scope = options.scope ? Constants.defaultScopes + ' ' + options.scope : Constants.defaultScopes;
        _environment = options.environment || 'production';
        _apiEndpoint = Constants.environments[_environment];
        _authorizationEndpoint = Constants.identityServers[_environment] + Constants.authorizeResource;

        if (window.location.hash) {
            var signedIn = _processTokenCallback();

            
        }

        if (!signedIn) {
            _initLoginButtons();
        }
    };

    var checkConnected = function (callback) {
        var cookie = Cookies.get('JGOAUTH');
        var result;
        if (cookie) {
            try {
                result = JSON.parse(cookie);
            } catch (e) {
                result = {
                    connected: false
                };
            }

        } else {
            result = {
                connected: false
            };
        }

        callback(result);
    }

    var signOut = function () {
        Cookies.expire('JGOAUTH');
    }

    var getFundraisingPages = function (callback, errorCallback) {

        var request = _createRequest('GET', '/v1/fundraising/pages');

        request.onload = function () {
            if (request.status >= 200 && request.status < 400) {
                var data = JSON.parse(request.responseText);
                callback(data);
            }
        };

        request.onerror = function () {
            if (errorCallback) {
                errorCallback();
            }
        };

        request.send();
    }


    var getFeed = function (callback, errorCallback) {

        var request = _createRequest('GET', '/v1/account/feed');

        request.onload = function () {
            if (request.status >= 200 && request.status < 400) {
                var data = JSON.parse(request.responseText);
                callback(data);
            } 
        };

        request.onerror = function () {
            if (errorCallback) {
                errorCallback();
            }
        };

        request.send();
    }

    var _createRequest = function (method, resource) {
        var request = new XMLHttpRequest();

        request.open(method, _apiEndpoint + resource, true);
        if (_accessToken) {
            request.setRequestHeader('Authorization', 'Bearer ' + _accessToken);
        }
        request.setRequestHeader('x-app-id', _appId);
        request.setRequestHeader('Accept', 'application/json');

        return request;
    }

    var _getToken = function () {
       
        var redirectUri = document.location.href.match(/(^[^#]*)/)[0];
        var responseType = "id_token token";
        var state = Date.now() + "" + Math.random();
        var nonce = Math.random();

        localStorage["state"] = state;

        var url =
            _authorizationEndpoint + "?" +
                "client_id=" + encodeURI(_appId) + "&" +
                "redirect_uri=" + encodeURI(redirectUri) + "&" +
                "response_type=" + encodeURI(responseType) + "&" +
                "scope=" + encodeURI(_scope) + "&" +
                "state=" + encodeURI(state) + "&" +
                "nonce=" + encodeURI(nonce);
        window.location = url;
    };

    var _processTokenCallback = function () {
        var hash = window.location.hash.substr(1);
        var result = hash.split('&').reduce(function (result, item) {
            var parts = item.split('=');
            result[parts[0]] = parts[1];
            return result;
        }, {});


        var success = !result.error;

        var idToken = {};
        if (success) {
            if (result.state !== localStorage["state"]) {
                success = false;
            } else {
                localStorage.removeItem("state");
                _accessToken = result.access_token;
                idToken = jwt_decode(result.id_token);
            }
        }
		
		var data = false;

        if (success) {

            data = {
                connected: true,
                accessToken: result.access_token,
                displayName: idToken.name,
                userId: idToken.sub,
                email: idToken.email
            }

            Cookies.set('JGOAUTH', JSON.stringify(data), { expires: result.expires });
        } else {
			 Cookies.expire('JGOAUTH');
        }

        var loginButtons = document.querySelectorAll('jg-login');

        [].forEach.call(loginButtons, function (loginButton) {
            if (loginButton.getAttribute('onlogin')) {
                var methodName = loginButton.getAttribute('onlogin');
                var callback = window[methodName];
                callback(data);
            }
        });

        return success;
    };

    var _initLoginButtons = function () {

        var loginButtons = document.querySelectorAll('jg-login');

        [].forEach.call(loginButtons, function (loginButton) {
            loginButton.innerHTML = "Connect with JustGiving";
            loginButton.style.fontWeight = 400;
            loginButton.style.fontFamily = 'roboto, arial';
            loginButton.style.textDecoration = 'none';
            loginButton.style.display = 'inline';
            loginButton.style.width = 'auto';
            loginButton.style.whiteSpace = 'normal';
            loginButton.style.verticalAlign = 'top';
            loginButton.style.padding = '0.5em';
            loginButton.style.cursor = 'pointer';
            loginButton.style.color = '#ffffff';
            loginButton.style.background = '#882c84';
            loginButton.style.fontSize = '100%';
            loginButton.style.borderRadius = '2px';
            loginButton.style.fontSmoothingEnabled = true;
            loginButton.style.textAlign = 'center';
            loginButton.style.marginTop = "64px";

            loginButton.addEventListener('click', function (e) {
                _getToken();
            });
        });
    }

    var Constants = (function() {

        var defaultScopes = 'openid profile email fundraise account';
        var authorizeResource = '/connect/authorize';
        var environments = new Array();
        environments['local'] = "http://api.local.justgiving.com";
        environments['dev'] = "https://api-integration.staging.justgiving.com";
        environments['staging'] = "https://api-integration.staging.justgiving.com";
        environments['sandbox'] = "https://api-sandbox.justgiving.com";
        environments['production'] = "https://api.justgiving.com";

        var identityServers = new Array();
        identityServers['local'] = "https://identity.local.justgiving.com";
        identityServers['dev'] = "https://identity.dev.justgiving.com";
        identityServers['staging'] = "https://identity.staging.justgiving.com";
        identityServers['sandbox'] = "https://identity.sandbox.justgiving.com";
        identityServers['production'] = "https://identity.justgiving.com";

        return {
            defaultScopes: defaultScopes,
            authorizeResource: authorizeResource,
            environments: environments,
            identityServers: identityServers
        };
    })();

    var CustomElements = (function () {

        var register = function() {
            _loginButton();
        };

        var _loginButton = function() {
            document.registerElement('jg-login', {
                prototype: Object.create(HTMLSpanElement.prototype),
                extends: 'span'
            });
        }

        return {
            register: register
        }
    })();

    return {
        init: init,
        checkConnected: checkConnected,
        signOut: signOut,
        getFundraisingPages: getFundraisingPages,
        getFeed: getFeed,
        CustomElements: CustomElements
    };

})();

window.onload = function () {
    
}