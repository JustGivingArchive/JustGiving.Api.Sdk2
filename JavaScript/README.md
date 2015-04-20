JavaScript SDK
==============


JG.js
-----

Simple example showing use of OAuth.
Built with Grunt.


JG-edge.js
----------

Modern JG client using the Fetch API and promises.
Works in IE10 and above using polyfills.

Built with ES6 and transpiled using Babel to ES5.
Built with Gulp. Tested with Mocha/Sinon/Shouldjs. Linted with ESLint. Minified with Uglify.

Browser-based example - ```jg-edge.example.html```

To get the latest dependencies, build and run tests:

```bash
npm update
gulp
```

To run the example, please create a credentials.js file in this directory:

```json
credentials = {
  "appId": "{your app ID}",
  "basicAuthToken": "Basic {your base64-encoded username/password}"
};
```
