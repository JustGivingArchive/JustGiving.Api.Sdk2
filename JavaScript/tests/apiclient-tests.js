"use strict";

var should = require('should'),
    fs = require('fs'),
    vm = require('vm'),
    sinon = require('sinon'),
    JG = require('../dist/justgiving-apiclient.js').ApiClient;

require('es6-promise').polyfill();

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

describe('Given JG client instance', function() {
  var mock, fetchMock, target = new JG('https://baseurl');

  beforeEach(function(){
    mock = sinon.mock(global);
    fetchMock = mock.expects("fetch")
                    .returns(Promise.resolve());
  });

  afterEach(function() {
    mock.restore();
  });

  it('should pass appID header', function() {
    var headersMock = mock.expects("Headers")
      .withArgs({'x-app-id': this._appId, Accept: 'application/json'})
      .once();

    target.getCountries();
    headersMock.verify();
  });

  it('should make successful getCountries request', function() {
    fetchMock
      .withArgs('https://baseurl/v1/countries')
      .once();

    target.getCountries();
    mock.verify();
  });

  describe('when checkAccountAvailability with valid local-part smtp address', function() {
    it('should pass the email address correctly', function() {
      fetchMock
        .withArgs('https://baseurl/v1/account/!%23%24%25%26\'()*%2B%2C%3B%3D%3A.%40example.org')
        .once();

      target.checkAccountAvailability('!#$%&\'()*+,;=:.@example.org');
      mock.verify();
    });
  });

  describe('when checkAccountAvailability with GMail account alias', function() {
    it('should pass the email address correctly', function() {
      fetchMock
        .withArgs('https://baseurl/v1/account/test%2Baccount%40gmail.com')
        .once();

      target.checkAccountAvailability('test+account@gmail.com');
      mock.verify();
    });
  });

  describe('when getCharity', function() {
    it('should pass charityID', function() {
      fetchMock
        .withArgs('https://baseurl/v1/charity/42')
        .once();

      target.getCharity(42);
      mock.verify();
    });
  });

  describe('when getDonation', function() {
    it('should pass donationID', function() {
      fetchMock
        .withArgs('https://baseurl/v1/donation/42')
        .once();

      target.getDonation(42);
      mock.verify();
    });
  });

  describe('when getDonationStatus', function() {
    it('should pass donationID', function() {
      fetchMock
        .withArgs('https://baseurl/v1/donation/42/status')
        .once();

      target.getDonationStatus(42);
      mock.verify();
    });
  });

  describe('when getEvent', function() {
    it('should pass eventID', function() {
      fetchMock
        .withArgs('https://baseurl/v1/event/42')
        .once();

      target.getEvent(42);
      mock.verify();
    });
  });

  describe('when getEventPages without specifying page', function() {
    it('should pass eventID', function() {
      fetchMock
        .withArgs('https://baseurl/v1/event/42/pages?')
        .once();

      target.getEventPages(42);
      mock.verify();
    });
  });

  describe('when getEventPages with page details', function() {
    it('should pass pageSize and pageNum', function() {
      fetchMock
        .withArgs('https://baseurl/v1/event/42/pages?pageSize=10&page=3&')
        .once();

      target.getEventPages(42, 10, 3);
      mock.verify();
    });
  });

  describe('when getProject', function() {
    it('should pass projectID', function() {
      fetchMock
        .withArgs('https://baseurl/v1/project/global/42')
        .once();

      target.getProject(42);
      mock.verify();
    });
  });

  describe('when getFundraisingPage', function() {
    it('should pass short name', function() {
      fetchMock
        .withArgs('https://baseurl/v1/fundraising/pages/my-short-name')
        .once();

      target.getFundraisingPage('my-short-name');
      mock.verify();
    });
  });
});
