"use strict";

var should = require('should'),
    fs = require('fs'),
    vm = require('vm'),
    sinon = require('sinon');

require('es6-promise').polyfill();

var code = fs.readFileSync('dist/JG-edge.js');
vm.runInThisContext(code);

// Fakes
global.Headers = function() {};
global.fetch = function(url, options){};

describe('Given JG class', function() {
   describe('when constructor called without URL', function() {
     it('should throw error', function() {
       (function() {new JG()}).should.throw('URL is required');
     });
   });

   describe('when constructor called correctly', function() {
     it('should create new instance', function() {
       new JG('https://api-sandbox.justgiving.com');
     });
   });
});

describe('Given JG client instance', function(){
  var target = new JG('https://baseurl');

  it('should make successful getCountries request', function(){
      var mock = sinon.mock(global);

      mock.expects("fetch")
        .returns(Promise.resolve())
        .withArgs('https://baseurl/v1/countries')
        .once();

      target.getCountries();
      mock.verify();
  });
});
