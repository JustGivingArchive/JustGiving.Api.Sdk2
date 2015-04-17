/**
 * JG - JustGiving API SDK
 * @version v2.0.0
 * @link https://api.justgiving.com/
 * @license WTFPL
 */
'use strict';

var _classCallCheck = function (instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError('Cannot call a class as a function'); } };

var _createClass = (function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ('value' in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; })();

var JG = (function () {
  function JG(url, appId, accessToken) {
    _classCallCheck(this, JG);

    if (typeof url !== 'string') throw new Error('URL is required');
    this._url = url;
    this._appId = appId;
    this._accessToken = accessToken;
    this._version = 'v1';
  }

  _createClass(JG, [{
    key: '_getOptions',
    value: function _getOptions(payload, method) {
      var options = { method: method || 'GET', headers: new Headers({ 'x-app-id': this._appId, Accept: 'application/json' }) };
      if (this._accessToken) {
        options.headers.append('Authorization', this._accessToken);
      }
      if (payload || method === 'POST') {
        options.method = method || 'POST';
        options.body = JSON.stringify(payload);
        options.headers.append('Content-Type', 'application/json');
      }
      return options;
    }
  }, {
    key: '_handleResponse',
    value: function _handleResponse(response) {
      if (response.status >= 400) {
        var contentType = response.headers.get('content-type');

        if (contentType && contentType.indexOf('application/json') === 0) {
          return response.json().then(function (json) {
            if (json[0]) {
              throw new Error('' + response.status + ' ' + response.statusText + '. ' + json[0].id + ' : ' + json[0].desc);
            }
          });
        }

        throw new Error('' + response.status + ' ' + response.statusText);
      }

      return response.json();
    }
  }, {
    key: '_fetch',
    value: function _fetch(resource, payload, method) {
      return fetch('' + this._url + '/' + this._version + '/' + resource, this._getOptions(payload, method)).then(this._handleResponse);
    }
  }, {
    key: 'validateAccount',

    // Account resource
    value: function validateAccount(email, password) {
      return this._fetch('account/validate', { email: email, password: password });
    }
  }, {
    key: 'getFundraisingPagesForUser',
    value: function getFundraisingPagesForUser(email, charityId) {
      var charityRestriction = charityId ? '?charityId=' + charityId : '';
      return this._fetch('account/' + email + '/pages' + charityRestriction);
    }
  }, {
    key: 'getDonationsForUser',
    value: function getDonationsForUser(pageSize, pageNum, charityId) {
      var charityRestriction = charityId ? 'charityId=' + charityId + '&' : '';
      var pageSizeRestriction = pageSize ? 'pageSize=' + pageSize + '&' : '';
      var pageNumRestriction = pageNum ? 'pageNum=' + pageNum + '&' : '';
      return this._fetch('account/donations?' + pageSizeRestriction + '' + pageNumRestriction + '' + charityRestriction);
    }
  }, {
    key: 'checkAccountAvailability',
    value: function checkAccountAvailability(email) {
      return this._fetch('account/' + email);
    }
  }, {
    key: 'getContentFeed',
    value: function getContentFeed() {
      return this._fetch('account/feed');
    }
  }, {
    key: 'getAccountRating',
    value: function getAccountRating(pageSize, pageNum) {
      var pageSizeRestriction = pageSize ? 'pageSize=' + pageSize + '&' : '';
      var pageNumRestriction = pageNum ? 'page=' + pageNum + '&' : '';
      return this._fetch('account/rating?' + pageSizeRestriction + '' + pageNumRestriction);
    }
  }, {
    key: 'getAccount',
    value: function getAccount() {
      return this._fetch('account');
    }
  }, {
    key: 'getInterests',
    value: function getInterests() {
      return this._fetch('account/interest');
    }
  }, {
    key: 'addInterest',
    value: function addInterest(interest) {
      return this._fetch('account/interest', { interest: interest });
    }
  }, {
    key: 'replaceInterests',
    value: function replaceInterests() {
      for (var _len = arguments.length, interests = Array(_len), _key = 0; _key < _len; _key++) {
        interests[_key] = arguments[_key];
      }

      return this._fetch('account/interest', interests, 'PUT');
    }
  }, {
    key: 'requestPasswordReminder',
    value: function requestPasswordReminder(email) {
      return this._fetch('account/' + email + '/requestpasswordreminder');
    }
  }, {
    key: 'changePassword',
    value: function changePassword(email, currentPassword, newPassword) {
      if (!email || !currentPassword || !newPassword) throw new Error('All parameters are required');
      return this._fetch('account/changePassword?emailaddress=' + email + '&currentpassword=' + encodeURIComponent(currentPassword) + '&newpassword=' + encodeURIComponent(newPassword), undefined, 'POST');
    }
  }, {
    key: 'getCountries',

    // Countries resource
    value: function getCountries() {
      return this._fetch('countries');
    }
  }, {
    key: 'getCurrencies',

    // Currency resource
    value: function getCurrencies() {
      return this._fetch('fundraising/currencies');
    }
  }, {
    key: 'getCharityCategories',

    // Charity resource
    value: function getCharityCategories() {
      return this._fetch('charity/categories');
    }
  }, {
    key: 'getCharity',
    value: function getCharity(charityId) {
      return this._fetch('charity/' + charityId);
    }
  }, {
    key: 'getEventsByCharity',
    value: function getEventsByCharity(charityId, pageSize, pageNum) {
      var pageSizeRestriction = pageSize ? 'pageSize=' + pageSize + '&' : '';
      var pageNumRestriction = pageNum ? 'pageNum=' + pageNum + '&' : '';

      return this._fetch('charity/' + charityId + '/events?' + pageSizeRestriction + '' + pageNumRestriction);
    }
  }, {
    key: 'getDonation',

    // Donation resource
    value: function getDonation(donationId) {
      return this._fetch('donation/' + donationId);
    }
  }, {
    key: 'getDonationByReference',
    value: function getDonationByReference(thirdPartyReference) {
      return this._fetch('donation/ref/' + encodeURIComponent(thirdPartyReference));
    }
  }, {
    key: 'getDonationStatus',
    value: function getDonationStatus(donationId) {
      return this._fetch('donation/' + donationId + '/status');
    }
  }, {
    key: 'getEvent',

    // Event resource
    value: function getEvent(eventId) {
      return this._fetch('event/' + eventId);
    }
  }, {
    key: 'getEventPages',
    value: function getEventPages(eventId, pageSize, pageNum) {
      var pageSizeRestriction = pageSize ? 'pageSize=' + pageSize + '&' : '';
      var pageNumRestriction = pageNum ? 'page=' + pageNum + '&' : '';

      return this._fetch('event/' + eventId + '/pages?' + pageSizeRestriction + '' + pageNumRestriction);
    }
  }, {
    key: 'registerEvent',
    value: function registerEvent(eventDetails) {
      return this._fetch('event', eventDetails);
    }
  }, {
    key: 'getFundraisingPages',

    // Fundraising resource
    value: function getFundraisingPages() {
      return this._fetch('fundraising/pages');
    }
  }, {
    key: 'getFundraisingPage',
    value: function getFundraisingPage(pageShortName) {
      return this._fetch('fundraising/pages/' + encodeURIComponent(pageShortName));
    }
  }, {
    key: 'suggestPageShortName',
    value: function suggestPageShortName(preferredName) {
      return this._fetch('fundraising/pages/suggest?preferredName=' + encodeURIComponent(preferredName));
    }
  }, {
    key: 'onesearch',

    // OneSearch resource
    value: function onesearch(searchTerm, grouping, index, pageSize, pageNum, country) {
      return this._fetch('onesearch?q=' + encodeURIComponent(searchTerm) + '&g=' + encodeURIComponent(grouping) + '&i=' + encodeURIComponent(index) + '&limit=' + pageSize + '&offset=' + pageNum + '&country=' + country);
    }
  }, {
    key: 'getProject',

    // Project resource
    value: function getProject(projectId) {
      return this._fetch('project/global/' + projectId);
    }
  }, {
    key: 'searchCharities',

    // Search resource
    value: function searchCharities(searchTerm, charityId, categoryId, pageNum, pageSize) {
      var pageSizeRestriction = pageSize ? 'pageSize=' + pageSize + '&' : '';
      var pageNumRestriction = pageNum ? 'page=' + pageNum + '&' : '';
      var charityIdRestriction = charityId.length ? charityId.map(function (id) {
        return 'charityId=' + id + '&';
      }).join() : 'charityId=' + charityId + '&';
      var categoryIdRestriction = categoryId.length ? categoryId.map(function (id) {
        return 'categoryId=' + id + '&';
      }).join() : 'categoryId=' + categoryId + '&';
      return this._fetch('charity/search?q=' + encodeURIComponent(searchTerm) + '&' + categoryIdRestriction + '' + charityIdRestriction + '' + pageSizeRestriction + '' + pageNumRestriction);
    }
  }, {
    key: 'searchEvents',
    value: function searchEvents(searchTerm, pageNum, pageSize) {
      var pageSizeRestriction = pageSize ? 'pageSize=' + pageSize + '&' : '';
      var pageNumRestriction = pageNum ? 'page=' + pageNum + '&' : '';
      return this._fetch('event/search?q=' + encodeURIComponent(searchTerm) + '&' + pageSizeRestriction + '' + pageNumRestriction);
    }
  }, {
    key: 'getTeam',

    // Team resource
    value: function getTeam(shortName) {
      return this._fetch('team/' + encodeURIComponent(shortName));
    }
  }, {
    key: 'checkTeamExists',
    value: function checkTeamExists(shortName) {
      return this._fetch('team/' + encodeURIComponent(shortName), undefined, 'HEAD');
    }
  }, {
    key: 'createOrUpdateTeam',
    value: function createOrUpdateTeam(shortName, details) {
      return this._fetch('team/' + encodeURIComponent(shortName), details, 'PUT');
    }
  }, {
    key: 'joinTeam',
    value: function joinTeam(teamShortName, pageShortName) {
      return this._fetch('team/join/' + encodeURIComponent(teamShortName), { pageShortName: pageShortName }, 'PUT');
    }
  }]);

  return JG;
})();
//# sourceMappingURL=JG-edge.js.map