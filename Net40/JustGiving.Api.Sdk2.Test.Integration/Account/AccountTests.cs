using System;
using System.Linq;
using System.Net;
using JustGiving.Api.Sdk2.Model.Account.Request;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Account
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void CreateAccount()
        {
            var client = TestContext.CreateAnonymousClient();
            string username;
            string password;
            var reg = AccountHelper.CreateRegistration(out username, out password);

            var response = client.Accounts.AccountRegistration(reg);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CreateAndValidateAccount()
        {
            var client = TestContext.CreateAnonymousClient();
            string username;
            string password;
            var reg = AccountHelper.CreateRegistration(out username, out password);

            client.Accounts.AccountRegistration(reg);

            var response = client.Accounts.Validate(new ValidateUserRequest()
            {
                Email = username,
                Password = password
            });

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void CreateAndRetrieveAccount()
        {
            var client = TestContext.CreateAnonymousClient();
            string username;
            string password;
            var reg = AccountHelper.CreateRegistration(out username, out password);

            client.Accounts.AccountRegistration(reg);

            client = TestContext.CreateBasicAuthClient(username, password);

            var response = client.Accounts.RetrieveAccount();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Email, Is.EqualTo(username));
        }

        [Test]
        public void GetPagesForUser()
        {
            var client = TestContext.CreateAnonymousClient();
            var response = client.Accounts.GetFundraisingPagesForUser("jamie@justgiving.com");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetDonationsForUser()
        {
            var client = TestContext.CreateBasicAuthClientAndUser();

            var response = client.Accounts.GetDonationsForUser(2050);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
        }

        [Test]
        public void AccountAvailability()
        {
            var client = TestContext.CreateAnonymousClient();

            var doesntExist = Guid.NewGuid() + "@justgiving.com";
            var response = client.Accounts.AccountAvailabilityCheck(doesntExist);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            
            string username;
            string password;
            var reg = AccountHelper.CreateRegistration(out username, out password);

            client.Accounts.AccountRegistration(reg);
            response = client.Accounts.AccountAvailabilityCheck(username);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void RateContent()
        {
            var client = TestContext.CreateBasicAuthClientAndUser();

            var response = client.Accounts.RateContent(new RateContentRequest
            {
                ContentData = "a-cool-page",
                Created = DateTime.Now,
                Intent = RatingIntent.Like,
                Type = RatingType.FundraisingPage
            });

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void GetUserContentRatingHistory()
        {
            var client = TestContext.CreateBasicAuthClientAndUser();

            client.Accounts.RateContent(new RateContentRequest
            {
                ContentData = "a-cool-page",
                Created = DateTime.Now,
                Intent = RatingIntent.Like,
                Type = RatingType.FundraisingPage
            });

            var response = client.Accounts.GetUserContentRatingHistory();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Ratings.Count == 1);
            Assert.That(response.Data.Ratings.First().ContentData == "a-cool-page");
        }

        [Test]
        public void GetUserContentFeed()
        {
            var client = TestContext.CreateBasicAuthClientAndUser();

            var response = client.Accounts.GetContentFeed();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
        }

        [Test]
        public void InterestsAdd()
        {
            var client = TestContext.CreateBasicAuthClientAndUser();

            var response = client.Accounts.InterestsAdd("brewing beer");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void InterestsGet()
        {
            var client = TestContext.CreateBasicAuthClientAndUser();

            client.Accounts.InterestsAdd("brewing beer");
            client.Accounts.InterestsAdd("riding bikes");

            var response = client.Accounts.InterestsGet();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Count, Is.GreaterThan(0));
            Assert.That(response.Data.Contains("brewing beer"));
            Assert.That(response.Data.Contains("riding bikes"));
        }

        [Test]
        public void InterestsReplace()
        {
            var client = TestContext.CreateBasicAuthClientAndUser();

            client.Accounts.InterestsAdd("brewing beer");
            client.Accounts.InterestsAdd("riding bikes");

            client.Accounts.InterestsReplace("riding horses", "brewing trouble");

            var response = client.Accounts.InterestsGet();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Count, Is.GreaterThan(0));
            Assert.That(response.Data.Contains("brewing beer"), Is.False);
            Assert.That(response.Data.Contains("riding bikes"), Is.False);
            Assert.That(response.Data.Contains("riding horses"));
            Assert.That(response.Data.Contains("brewing trouble"));
        }
    }
}
