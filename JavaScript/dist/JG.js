/*! JG 2015-04-01 */
!function(a,b){"use strict";var c=function(a){if("object"!=typeof a.document)throw new Error("Cookies.js requires a `window` with a `document` object");var c=function(a,b,d){return 1===arguments.length?c.get(a):c.set(a,b,d)};return c._document=a.document,c._cacheKeyPrefix="cookey.",c._maxExpireDate=new Date("Fri, 31 Dec 9999 23:59:59 UTC"),c.defaults={path:"/",secure:!1},c.get=function(a){return c._cachedDocumentCookie!==c._document.cookie&&c._renewCache(),c._cache[c._cacheKeyPrefix+a]},c.set=function(a,d,e){return e=c._getExtendedOptions(e),e.expires=c._getExpiresDate(d===b?-1:e.expires),c._document.cookie=c._generateCookieString(a,d,e),c},c.expire=function(a,d){return c.set(a,b,d)},c._getExtendedOptions=function(a){return{path:a&&a.path||c.defaults.path,domain:a&&a.domain||c.defaults.domain,expires:a&&a.expires||c.defaults.expires,secure:a&&a.secure!==b?a.secure:c.defaults.secure}},c._isValidDate=function(a){return"[object Date]"===Object.prototype.toString.call(a)&&!isNaN(a.getTime())},c._getExpiresDate=function(a,b){if(b=b||new Date,"number"==typeof a?a=a===1/0?c._maxExpireDate:new Date(b.getTime()+1e3*a):"string"==typeof a&&(a=new Date(a)),a&&!c._isValidDate(a))throw new Error("`expires` parameter cannot be converted to a valid Date instance");return a},c._generateCookieString=function(a,b,c){a=a.replace(/[^#$&+\^`|]/g,encodeURIComponent),a=a.replace(/\(/g,"%28").replace(/\)/g,"%29"),b=(b+"").replace(/[^!#$&-+\--:<-\[\]-~]/g,encodeURIComponent),c=c||{};var d=a+"="+b;return d+=c.path?";path="+c.path:"",d+=c.domain?";domain="+c.domain:"",d+=c.expires?";expires="+c.expires.toUTCString():"",d+=c.secure?";secure":""},c._getCacheFromString=function(a){for(var d={},e=a?a.split("; "):[],f=0;f<e.length;f++){var g=c._getKeyValuePairFromCookieString(e[f]);d[c._cacheKeyPrefix+g.key]===b&&(d[c._cacheKeyPrefix+g.key]=g.value)}return d},c._getKeyValuePairFromCookieString=function(a){var b=a.indexOf("=");return b=0>b?a.length:b,{key:decodeURIComponent(a.substr(0,b)),value:decodeURIComponent(a.substr(b+1))}},c._renewCache=function(){c._cache=c._getCacheFromString(c._document.cookie),c._cachedDocumentCookie=c._document.cookie},c._areEnabled=function(){var a="cookies.js",b="1"===c.set(a,1).get(a);return c.expire(a),b},c.enabled=c._areEnabled(),c},d="object"==typeof a.document?c(a):c;"function"==typeof define&&define.amd?define(function(){return d}):"object"==typeof exports?("object"==typeof module&&"object"==typeof module.exports&&(exports=module.exports=d),exports.Cookies=d):a.Cookies=d}("undefined"==typeof window?this:window),function a(b,c,d){function e(g,h){if(!c[g]){if(!b[g]){var i="function"==typeof require&&require;if(!h&&i)return i(g,!0);if(f)return f(g,!0);throw new Error("Cannot find module '"+g+"'")}var j=c[g]={exports:{}};b[g][0].call(j.exports,function(a){var c=b[g][1][a];return e(c?c:a)},j,j.exports,a,b,c,d)}return c[g].exports}for(var f="function"==typeof require&&require,g=0;g<d.length;g++)e(d[g]);return e}({1:[function(a,b){var c=a("Base64");b.exports=function(a){var b=a.replace("-","+").replace("_","/");switch(b.length%4){case 0:break;case 2:b+="==";break;case 3:b+="=";break;default:throw"Illegal base64url string!"}var d=c.atob(b);try{return decodeURIComponent(escape(d))}catch(e){return d}}},{Base64:4}],2:[function(a,b){var c=a("./base64_url_decode"),d=a("./json_parse");b.exports=function(a){return d(c(a.split(".")[1]))}},{"./base64_url_decode":1,"./json_parse":3}],3:[function(require,module,exports){module.exports=function(str){return window.JSON?window.JSON.parse(str):eval("("+str+")")}},{}],4:[function(a,b,c){!function(){var a="undefined"!=typeof c?c:this,b="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",d=function(){try{document.createElement("$")}catch(a){return a}}();a.btoa||(a.btoa=function(a){for(var c,e,f=0,g=b,h="";a.charAt(0|f)||(g="=",f%1);h+=g.charAt(63&c>>8-f%1*8)){if(e=a.charCodeAt(f+=.75),e>255)throw d;c=c<<8|e}return h}),a.atob||(a.atob=function(a){if(a=a.replace(/=+$/,""),a.length%4==1)throw d;for(var c,e,f=0,g=0,h="";e=a.charAt(g++);~e&&(c=f%4?64*c+e:e,f++%4)?h+=String.fromCharCode(255&c>>(-2*f&6)):0)e=b.indexOf(e);return h})}()},{}],5:[function(a){var b="undefined"!=typeof self?self:"undefined"!=typeof window?window:{},c=a("./lib/index");"function"==typeof b.window.define&&b.window.define.amd?b.window.define("jwt_decode",function(){return c}):b.window&&(b.window.jwt_decode=c)},{"./lib/index":2}]},{},[5]);var JG=function(){var a,b,c,d,e,f,g=function(f){if(JG.CustomElements.register(),a=f.appId,b=f.scope?p.defaultScopes+" "+f.scope:p.defaultScopes,c=f.environment||"production",d=p.environments[c],e=p.identityServers[c]+p.authorizeResource,window.location.hash)var g=n();g||o()},h=function(a){var b,c=Cookies.get("JGOAUTH");if(c)try{b=JSON.parse(c)}catch(d){b={connected:!1}}else b={connected:!1};a(b)},i=function(){Cookies.expire("JGOAUTH")},j=function(a,b){var c=l("GET","/v1/fundraising/pages");c.onload=function(){if(c.status>=200&&c.status<400){var b=JSON.parse(c.responseText);a(b)}},c.onerror=function(){b&&b()},c.send()},k=function(a,b){var c=l("GET","/v1/account/feed");c.onload=function(){if(c.status>=200&&c.status<400){var b=JSON.parse(c.responseText);a(b)}},c.onerror=function(){b&&b()},c.send()},l=function(b,c){var e=new XMLHttpRequest;return e.open(b,d+c,!0),f&&e.setRequestHeader("Authorization","Bearer "+f),e.setRequestHeader("x-app-id",a),e.setRequestHeader("Accept","application/json"),e},m=function(){var c=document.location.href.match(/(^[^#]*)/)[0],d="id_token token",f=Date.now()+""+Math.random(),g=Math.random();localStorage.state=f;var h=e+"?client_id="+encodeURI(a)+"&redirect_uri="+encodeURI(c)+"&response_type="+encodeURI(d)+"&scope="+encodeURI(b)+"&state="+encodeURI(f)+"&nonce="+encodeURI(g);window.location=h},n=function(){var a=window.location.hash.substr(1),b=a.split("&").reduce(function(a,b){var c=b.split("=");return a[c[0]]=c[1],a},{}),c=!b.error,d={};if(c&&(b.state!==localStorage.state?c=!1:(localStorage.removeItem("state"),f=b.access_token,d=jwt_decode(b.id_token))),c){var e={connected:!0,accessToken:b.access_token,displayName:d.name,userId:d.sub,email:d.email};Cookies.set("JGOAUTH",JSON.stringify(e),{expires:b.expires})}else Cookies.expire("JGOAUTH");var g=document.querySelectorAll("jg-login");return[].forEach.call(g,function(a){if(a.getAttribute("onlogin")){var b=a.getAttribute("onlogin"),c=window[b];c()}}),c},o=function(){var a=document.querySelectorAll("jg-login");[].forEach.call(a,function(a){a.innerHTML="Connect with JustGiving",a.style.fontWeight=400,a.style.fontFamily="roboto, arial",a.style.textDecoration="none",a.style.display="inline",a.style.width="auto",a.style.whiteSpace="normal",a.style.verticalAlign="top",a.style.padding="0.5em",a.style.cursor="pointer",a.style.color="#ffffff",a.style.background="#882c84",a.style.fontSize="100%",a.style.borderRadius="2px",a.style.fontSmoothingEnabled=!0,a.style.textAlign="center",a.style.marginTop="64px",a.addEventListener("click",function(){m()})})},p=function(){var a="openid profile email fundraise account",b="/connect/authorize",c=new Array;c.local="http://api.local.justgiving.com",c.dev="https://api-integration.staging.justgiving.com",c.staging="https://api-integration.staging.justgiving.com",c.sandbox="https://api-sandbox.justgiving.com",c.production="https://api.justgiving.com";var d=new Array;return d.local="https://identity.local.justgiving.com",d.dev="https://identity.dev.justgiving.com",d.staging="https://identity.staging.justgiving.com",d.sandbox="https://identity.sandbox.justgiving.com",d.production="https://identity.justgiving.com",{defaultScopes:a,authorizeResource:b,environments:c,identityServers:d}}(),q=function(){var a=function(){b()},b=function(){document.registerElement("jg-login",{prototype:Object.create(HTMLSpanElement.prototype),"extends":"span"})};return{register:a}}();return{init:g,checkConnected:h,signOut:i,getFundraisingPages:j,getFeed:k,CustomElements:q}}();window.onload=function(){};;/*
 * Cookies.js - 1.2.1
 * https://github.com/ScottHamper/Cookies
 *
 * This is free and unencumbered software released into the public domain.
 */
(function (global, undefined) {
    'use strict';

    var factory = function (window) {
        if (typeof window.document !== 'object') {
            throw new Error('Cookies.js requires a `window` with a `document` object');
        }

        var Cookies = function (key, value, options) {
            return arguments.length === 1 ?
                Cookies.get(key) : Cookies.set(key, value, options);
        };

        // Allows for setter injection in unit tests
        Cookies._document = window.document;

        // Used to ensure cookie keys do not collide with
        // built-in `Object` properties
        Cookies._cacheKeyPrefix = 'cookey.'; // Hurr hurr, :)
        
        Cookies._maxExpireDate = new Date('Fri, 31 Dec 9999 23:59:59 UTC');

        Cookies.defaults = {
            path: '/',
            secure: false
        };

        Cookies.get = function (key) {
            if (Cookies._cachedDocumentCookie !== Cookies._document.cookie) {
                Cookies._renewCache();
            }

            return Cookies._cache[Cookies._cacheKeyPrefix + key];
        };

        Cookies.set = function (key, value, options) {
            options = Cookies._getExtendedOptions(options);
            options.expires = Cookies._getExpiresDate(value === undefined ? -1 : options.expires);

            Cookies._document.cookie = Cookies._generateCookieString(key, value, options);

            return Cookies;
        };

        Cookies.expire = function (key, options) {
            return Cookies.set(key, undefined, options);
        };

        Cookies._getExtendedOptions = function (options) {
            return {
                path: options && options.path || Cookies.defaults.path,
                domain: options && options.domain || Cookies.defaults.domain,
                expires: options && options.expires || Cookies.defaults.expires,
                secure: options && options.secure !== undefined ?  options.secure : Cookies.defaults.secure
            };
        };

        Cookies._isValidDate = function (date) {
            return Object.prototype.toString.call(date) === '[object Date]' && !isNaN(date.getTime());
        };

        Cookies._getExpiresDate = function (expires, now) {
            now = now || new Date();

            if (typeof expires === 'number') {
                expires = expires === Infinity ?
                    Cookies._maxExpireDate : new Date(now.getTime() + expires * 1000);
            } else if (typeof expires === 'string') {
                expires = new Date(expires);
            }

            if (expires && !Cookies._isValidDate(expires)) {
                throw new Error('`expires` parameter cannot be converted to a valid Date instance');
            }

            return expires;
        };

        Cookies._generateCookieString = function (key, value, options) {
            key = key.replace(/[^#$&+\^`|]/g, encodeURIComponent);
            key = key.replace(/\(/g, '%28').replace(/\)/g, '%29');
            value = (value + '').replace(/[^!#$&-+\--:<-\[\]-~]/g, encodeURIComponent);
            options = options || {};

            var cookieString = key + '=' + value;
            cookieString += options.path ? ';path=' + options.path : '';
            cookieString += options.domain ? ';domain=' + options.domain : '';
            cookieString += options.expires ? ';expires=' + options.expires.toUTCString() : '';
            cookieString += options.secure ? ';secure' : '';

            return cookieString;
        };

        Cookies._getCacheFromString = function (documentCookie) {
            var cookieCache = {};
            var cookiesArray = documentCookie ? documentCookie.split('; ') : [];

            for (var i = 0; i < cookiesArray.length; i++) {
                var cookieKvp = Cookies._getKeyValuePairFromCookieString(cookiesArray[i]);

                if (cookieCache[Cookies._cacheKeyPrefix + cookieKvp.key] === undefined) {
                    cookieCache[Cookies._cacheKeyPrefix + cookieKvp.key] = cookieKvp.value;
                }
            }

            return cookieCache;
        };

        Cookies._getKeyValuePairFromCookieString = function (cookieString) {
            // "=" is a valid character in a cookie value according to RFC6265, so cannot `split('=')`
            var separatorIndex = cookieString.indexOf('=');

            // IE omits the "=" when the cookie value is an empty string
            separatorIndex = separatorIndex < 0 ? cookieString.length : separatorIndex;

            return {
                key: decodeURIComponent(cookieString.substr(0, separatorIndex)),
                value: decodeURIComponent(cookieString.substr(separatorIndex + 1))
            };
        };

        Cookies._renewCache = function () {
            Cookies._cache = Cookies._getCacheFromString(Cookies._document.cookie);
            Cookies._cachedDocumentCookie = Cookies._document.cookie;
        };

        Cookies._areEnabled = function () {
            var testKey = 'cookies.js';
            var areEnabled = Cookies.set(testKey, 1).get(testKey) === '1';
            Cookies.expire(testKey);
            return areEnabled;
        };

        Cookies.enabled = Cookies._areEnabled();

        return Cookies;
    };

    var cookiesExport = typeof global.document === 'object' ? factory(global) : factory;

    // AMD support
    if (typeof define === 'function' && define.amd) {
        define(function () { return cookiesExport; });
    // CommonJS/Node.js support
    } else if (typeof exports === 'object') {
        // Support Node.js specific `module.exports` (which can be a function)
        if (typeof module === 'object' && typeof module.exports === 'object') {
            exports = module.exports = cookiesExport;
        }
        // But always support CommonJS module 1.1.1 spec (`exports` cannot be a function)
        exports.Cookies = cookiesExport;
    } else {
        global.Cookies = cookiesExport;
    }
})(typeof window === 'undefined' ? this : window);
;(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);throw new Error("Cannot find module '"+o+"'")}var f=n[o]={exports:{}};t[o][0].call(f.exports,function(e){var n=t[o][1][e];return s(n?n:e)},f,f.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
var Base64 = require('Base64');

module.exports = function(str) {
  var output = str.replace("-", "+").replace("_", "/");
  switch (output.length % 4) {
    case 0:
      break;
    case 2:
      output += "==";
      break;
    case 3:
      output += "=";
      break;
    default:
      throw "Illegal base64url string!";
  }

  var result = Base64.atob(output);

  try{
    return decodeURIComponent(escape(result));
  } catch (err) {
    return result;
  }
};
},{"Base64":4}],2:[function(require,module,exports){
var base64_url_decode = require('./base64_url_decode');
var json_parse = require('./json_parse');

module.exports = function (token) {
  return json_parse(base64_url_decode(token.split('.')[1]));
};
},{"./base64_url_decode":1,"./json_parse":3}],3:[function(require,module,exports){
module.exports = function (str) {
  return window.JSON ? window.JSON.parse(str) : eval('(' + str + ')');
};
},{}],4:[function(require,module,exports){
;(function () {

  var
    object = typeof exports != 'undefined' ? exports : this, // #8: web workers
    chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=',
    INVALID_CHARACTER_ERR = (function () {
      // fabricate a suitable error object
      try { document.createElement('$'); }
      catch (error) { return error; }}());

  // encoder
  // [https://gist.github.com/999166] by [https://github.com/nignag]
  object.btoa || (
  object.btoa = function (input) {
    for (
      // initialize result and counter
      var block, charCode, idx = 0, map = chars, output = '';
      // if the next input index does not exist:
      //   change the mapping table to "="
      //   check if d has no fractional digits
      input.charAt(idx | 0) || (map = '=', idx % 1);
      // "8 - idx % 1 * 8" generates the sequence 2, 4, 6, 8
      output += map.charAt(63 & block >> 8 - idx % 1 * 8)
    ) {
      charCode = input.charCodeAt(idx += 3/4);
      if (charCode > 0xFF) throw INVALID_CHARACTER_ERR;
      block = block << 8 | charCode;
    }
    return output;
  });

  // decoder
  // [https://gist.github.com/1020396] by [https://github.com/atk]
  object.atob || (
  object.atob = function (input) {
    input = input.replace(/=+$/, '')
    if (input.length % 4 == 1) throw INVALID_CHARACTER_ERR;
    for (
      // initialize result and counters
      var bc = 0, bs, buffer, idx = 0, output = '';
      // get next character
      buffer = input.charAt(idx++);
      // character found in table? initialize bit storage and add its ascii value;
      ~buffer && (bs = bc % 4 ? bs * 64 + buffer : buffer,
        // and if not first of each 4 characters,
        // convert the first 8 bits to one ascii character
        bc++ % 4) ? output += String.fromCharCode(255 & bs >> (-2 * bc & 6)) : 0
    ) {
      // try to find character in table (0-63, not found => -1)
      buffer = chars.indexOf(buffer);
    }
    return output;
  });

}());

},{}],5:[function(require,module,exports){
var global=typeof self !== "undefined" ? self : typeof window !== "undefined" ? window : {};/*
 *
 * This is used to build the bundle with browserify.
 *
 * The bundle is used by people who doesn't use browserify.
 * Those who use browserify will install with npm and require the module,
 * the package.json file points to index.js.
 */
var jwt_decode = require('./lib/index');

//use amd or just throught to window object.
if (typeof global.window.define == 'function' && global.window.define.amd) {
  global.window.define('jwt_decode', function () { return jwt_decode; });
} else if (global.window) {
  global.window.jwt_decode = jwt_decode;
}
},{"./lib/index":2}]},{},[5])
//@ sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIi9Vc2Vycy9qb3NlL1Byb2plY3RzL29zcy9qd3QtZGVjb2RlL2xpYi9iYXNlNjRfdXJsX2RlY29kZS5qcyIsIi9Vc2Vycy9qb3NlL1Byb2plY3RzL29zcy9qd3QtZGVjb2RlL2xpYi9pbmRleC5qcyIsIi9Vc2Vycy9qb3NlL1Byb2plY3RzL29zcy9qd3QtZGVjb2RlL2xpYi9qc29uX3BhcnNlLmpzIiwiL1VzZXJzL2pvc2UvUHJvamVjdHMvb3NzL2p3dC1kZWNvZGUvbm9kZV9tb2R1bGVzL0Jhc2U2NC9iYXNlNjQuanMiLCIvVXNlcnMvam9zZS9Qcm9qZWN0cy9vc3Mvand0LWRlY29kZS9zdGFuZGFsb25lLmpzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUN4QkE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQ0xBO0FBQ0E7QUFDQTs7QUNGQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQ3ZEQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSIsImZpbGUiOiJnZW5lcmF0ZWQuanMiLCJzb3VyY2VSb290IjoiIiwic291cmNlc0NvbnRlbnQiOlsidmFyIEJhc2U2NCA9IHJlcXVpcmUoJ0Jhc2U2NCcpO1xuXG5tb2R1bGUuZXhwb3J0cyA9IGZ1bmN0aW9uKHN0cikge1xuICB2YXIgb3V0cHV0ID0gc3RyLnJlcGxhY2UoXCItXCIsIFwiK1wiKS5yZXBsYWNlKFwiX1wiLCBcIi9cIik7XG4gIHN3aXRjaCAob3V0cHV0Lmxlbmd0aCAlIDQpIHtcbiAgICBjYXNlIDA6XG4gICAgICBicmVhaztcbiAgICBjYXNlIDI6XG4gICAgICBvdXRwdXQgKz0gXCI9PVwiO1xuICAgICAgYnJlYWs7XG4gICAgY2FzZSAzOlxuICAgICAgb3V0cHV0ICs9IFwiPVwiO1xuICAgICAgYnJlYWs7XG4gICAgZGVmYXVsdDpcbiAgICAgIHRocm93IFwiSWxsZWdhbCBiYXNlNjR1cmwgc3RyaW5nIVwiO1xuICB9XG5cbiAgdmFyIHJlc3VsdCA9IEJhc2U2NC5hdG9iKG91dHB1dCk7XG5cbiAgdHJ5e1xuICAgIHJldHVybiBkZWNvZGVVUklDb21wb25lbnQoZXNjYXBlKHJlc3VsdCkpO1xuICB9IGNhdGNoIChlcnIpIHtcbiAgICByZXR1cm4gcmVzdWx0O1xuICB9XG59OyIsInZhciBiYXNlNjRfdXJsX2RlY29kZSA9IHJlcXVpcmUoJy4vYmFzZTY0X3VybF9kZWNvZGUnKTtcbnZhciBqc29uX3BhcnNlID0gcmVxdWlyZSgnLi9qc29uX3BhcnNlJyk7XG5cbm1vZHVsZS5leHBvcnRzID0gZnVuY3Rpb24gKHRva2VuKSB7XG4gIHJldHVybiBqc29uX3BhcnNlKGJhc2U2NF91cmxfZGVjb2RlKHRva2VuLnNwbGl0KCcuJylbMV0pKTtcbn07IiwibW9kdWxlLmV4cG9ydHMgPSBmdW5jdGlvbiAoc3RyKSB7XG4gIHJldHVybiB3aW5kb3cuSlNPTiA/IHdpbmRvdy5KU09OLnBhcnNlKHN0cikgOiBldmFsKCcoJyArIHN0ciArICcpJyk7XG59OyIsIjsoZnVuY3Rpb24gKCkge1xuXG4gIHZhclxuICAgIG9iamVjdCA9IHR5cGVvZiBleHBvcnRzICE9ICd1bmRlZmluZWQnID8gZXhwb3J0cyA6IHRoaXMsIC8vICM4OiB3ZWIgd29ya2Vyc1xuICAgIGNoYXJzID0gJ0FCQ0RFRkdISUpLTE1OT1BRUlNUVVZXWFlaYWJjZGVmZ2hpamtsbW5vcHFyc3R1dnd4eXowMTIzNDU2Nzg5Ky89JyxcbiAgICBJTlZBTElEX0NIQVJBQ1RFUl9FUlIgPSAoZnVuY3Rpb24gKCkge1xuICAgICAgLy8gZmFicmljYXRlIGEgc3VpdGFibGUgZXJyb3Igb2JqZWN0XG4gICAgICB0cnkgeyBkb2N1bWVudC5jcmVhdGVFbGVtZW50KCckJyk7IH1cbiAgICAgIGNhdGNoIChlcnJvcikgeyByZXR1cm4gZXJyb3I7IH19KCkpO1xuXG4gIC8vIGVuY29kZXJcbiAgLy8gW2h0dHBzOi8vZ2lzdC5naXRodWIuY29tLzk5OTE2Nl0gYnkgW2h0dHBzOi8vZ2l0aHViLmNvbS9uaWduYWddXG4gIG9iamVjdC5idG9hIHx8IChcbiAgb2JqZWN0LmJ0b2EgPSBmdW5jdGlvbiAoaW5wdXQpIHtcbiAgICBmb3IgKFxuICAgICAgLy8gaW5pdGlhbGl6ZSByZXN1bHQgYW5kIGNvdW50ZXJcbiAgICAgIHZhciBibG9jaywgY2hhckNvZGUsIGlkeCA9IDAsIG1hcCA9IGNoYXJzLCBvdXRwdXQgPSAnJztcbiAgICAgIC8vIGlmIHRoZSBuZXh0IGlucHV0IGluZGV4IGRvZXMgbm90IGV4aXN0OlxuICAgICAgLy8gICBjaGFuZ2UgdGhlIG1hcHBpbmcgdGFibGUgdG8gXCI9XCJcbiAgICAgIC8vICAgY2hlY2sgaWYgZCBoYXMgbm8gZnJhY3Rpb25hbCBkaWdpdHNcbiAgICAgIGlucHV0LmNoYXJBdChpZHggfCAwKSB8fCAobWFwID0gJz0nLCBpZHggJSAxKTtcbiAgICAgIC8vIFwiOCAtIGlkeCAlIDEgKiA4XCIgZ2VuZXJhdGVzIHRoZSBzZXF1ZW5jZSAyLCA0LCA2LCA4XG4gICAgICBvdXRwdXQgKz0gbWFwLmNoYXJBdCg2MyAmIGJsb2NrID4+IDggLSBpZHggJSAxICogOClcbiAgICApIHtcbiAgICAgIGNoYXJDb2RlID0gaW5wdXQuY2hhckNvZGVBdChpZHggKz0gMy80KTtcbiAgICAgIGlmIChjaGFyQ29kZSA+IDB4RkYpIHRocm93IElOVkFMSURfQ0hBUkFDVEVSX0VSUjtcbiAgICAgIGJsb2NrID0gYmxvY2sgPDwgOCB8IGNoYXJDb2RlO1xuICAgIH1cbiAgICByZXR1cm4gb3V0cHV0O1xuICB9KTtcblxuICAvLyBkZWNvZGVyXG4gIC8vIFtodHRwczovL2dpc3QuZ2l0aHViLmNvbS8xMDIwMzk2XSBieSBbaHR0cHM6Ly9naXRodWIuY29tL2F0a11cbiAgb2JqZWN0LmF0b2IgfHwgKFxuICBvYmplY3QuYXRvYiA9IGZ1bmN0aW9uIChpbnB1dCkge1xuICAgIGlucHV0ID0gaW5wdXQucmVwbGFjZSgvPSskLywgJycpXG4gICAgaWYgKGlucHV0Lmxlbmd0aCAlIDQgPT0gMSkgdGhyb3cgSU5WQUxJRF9DSEFSQUNURVJfRVJSO1xuICAgIGZvciAoXG4gICAgICAvLyBpbml0aWFsaXplIHJlc3VsdCBhbmQgY291bnRlcnNcbiAgICAgIHZhciBiYyA9IDAsIGJzLCBidWZmZXIsIGlkeCA9IDAsIG91dHB1dCA9ICcnO1xuICAgICAgLy8gZ2V0IG5leHQgY2hhcmFjdGVyXG4gICAgICBidWZmZXIgPSBpbnB1dC5jaGFyQXQoaWR4KyspO1xuICAgICAgLy8gY2hhcmFjdGVyIGZvdW5kIGluIHRhYmxlPyBpbml0aWFsaXplIGJpdCBzdG9yYWdlIGFuZCBhZGQgaXRzIGFzY2lpIHZhbHVlO1xuICAgICAgfmJ1ZmZlciAmJiAoYnMgPSBiYyAlIDQgPyBicyAqIDY0ICsgYnVmZmVyIDogYnVmZmVyLFxuICAgICAgICAvLyBhbmQgaWYgbm90IGZpcnN0IG9mIGVhY2ggNCBjaGFyYWN0ZXJzLFxuICAgICAgICAvLyBjb252ZXJ0IHRoZSBmaXJzdCA4IGJpdHMgdG8gb25lIGFzY2lpIGNoYXJhY3RlclxuICAgICAgICBiYysrICUgNCkgPyBvdXRwdXQgKz0gU3RyaW5nLmZyb21DaGFyQ29kZSgyNTUgJiBicyA+PiAoLTIgKiBiYyAmIDYpKSA6IDBcbiAgICApIHtcbiAgICAgIC8vIHRyeSB0byBmaW5kIGNoYXJhY3RlciBpbiB0YWJsZSAoMC02Mywgbm90IGZvdW5kID0+IC0xKVxuICAgICAgYnVmZmVyID0gY2hhcnMuaW5kZXhPZihidWZmZXIpO1xuICAgIH1cbiAgICByZXR1cm4gb3V0cHV0O1xuICB9KTtcblxufSgpKTtcbiIsInZhciBnbG9iYWw9dHlwZW9mIHNlbGYgIT09IFwidW5kZWZpbmVkXCIgPyBzZWxmIDogdHlwZW9mIHdpbmRvdyAhPT0gXCJ1bmRlZmluZWRcIiA/IHdpbmRvdyA6IHt9Oy8qXG4gKlxuICogVGhpcyBpcyB1c2VkIHRvIGJ1aWxkIHRoZSBidW5kbGUgd2l0aCBicm93c2VyaWZ5LlxuICpcbiAqIFRoZSBidW5kbGUgaXMgdXNlZCBieSBwZW9wbGUgd2hvIGRvZXNuJ3QgdXNlIGJyb3dzZXJpZnkuXG4gKiBUaG9zZSB3aG8gdXNlIGJyb3dzZXJpZnkgd2lsbCBpbnN0YWxsIHdpdGggbnBtIGFuZCByZXF1aXJlIHRoZSBtb2R1bGUsXG4gKiB0aGUgcGFja2FnZS5qc29uIGZpbGUgcG9pbnRzIHRvIGluZGV4LmpzLlxuICovXG52YXIgand0X2RlY29kZSA9IHJlcXVpcmUoJy4vbGliL2luZGV4Jyk7XG5cbi8vdXNlIGFtZCBvciBqdXN0IHRocm91Z2h0IHRvIHdpbmRvdyBvYmplY3QuXG5pZiAodHlwZW9mIGdsb2JhbC53aW5kb3cuZGVmaW5lID09ICdmdW5jdGlvbicgJiYgZ2xvYmFsLndpbmRvdy5kZWZpbmUuYW1kKSB7XG4gIGdsb2JhbC53aW5kb3cuZGVmaW5lKCdqd3RfZGVjb2RlJywgZnVuY3Rpb24gKCkgeyByZXR1cm4gand0X2RlY29kZTsgfSk7XG59IGVsc2UgaWYgKGdsb2JhbC53aW5kb3cpIHtcbiAgZ2xvYmFsLndpbmRvdy5qd3RfZGVjb2RlID0gand0X2RlY29kZTtcbn0iXX0=
;;var JG = (function () {

    var _appId, _scope, _environment, _apiEndpoint, _authorizationEndpoint, _accessToken;

    var init = function (options) {
        JG.CustomElements.register();
        _appId = options.appId;
        _scope = options.scope ? Constants.defaultScopes + ' ' + options.scope : Constants.defaultScopes;
        _environment = options.environment || 'production';
        _apiEndpoint = Constants.environments[_environment];
        _authorizationEndpoint = Constants.identityServers[_environment] + Constants.authorizeResource;

      var signedIn = false;
        if (window.location.hash) {
            signedIn = _processTokenCallback();
        }
    else {
        signedIn = checkConnected();
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
    return result.connected;
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