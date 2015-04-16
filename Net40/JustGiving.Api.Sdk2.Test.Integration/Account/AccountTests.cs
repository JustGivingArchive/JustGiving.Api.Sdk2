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
        public async void CreateAccount()
        {
            var client = TestContext.CreateAnonymousClient();
            string username;
            string password;
            var reg = AccountHelper.CreateRegistration(out username, out password);

            var response = await client.Accounts.AccountRegistration(reg);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async void CreateAndValidateAccount()
        {
            var client = TestContext.CreateAnonymousClient();
            string username;
            string password;
            var reg = AccountHelper.CreateRegistration(out username, out password);

            client.Accounts.AccountRegistration(reg);

            var response = await client.Accounts.Validate(new ValidateUserRequest()
            {
                Email = username,
                Password = password
            });

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async void CreateAndRetrieveAccount()
        {
            var client = TestContext.CreateAnonymousClient();
            string username;
            string password;
            var reg = AccountHelper.CreateRegistration(out username, out password);

            await client.Accounts.AccountRegistration(reg);

            client = TestContext.CreateBasicAuthClient(username, password);

            var response = await client.Accounts.RetrieveAccount();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Email, Is.EqualTo(username));
        }

        [Test]
        public async void GetPagesForUser()
        {
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Accounts.GetFundraisingPagesForUser("jamie@justgiving.com");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.GreaterThan(0));
        }

        [Test]
        public async void GetDonationsForUser()
        {
            var client = await TestContext.CreateBasicAuthClientAndUser();

            var response = await client.Accounts.GetDonationsForUser(2050);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
        }

        [Test]
        public async void AccountAvailability()
        {
            var client = TestContext.CreateAnonymousClient();

            var doesntExist = Guid.NewGuid() + "@justgiving.com";
            var response = await client.Accounts.AccountAvailabilityCheck(doesntExist);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            
            string username;
            string password;
            var reg = AccountHelper.CreateRegistration(out username, out password);

            await client.Accounts.AccountRegistration(reg);
            response = await client.Accounts.AccountAvailabilityCheck(username);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async void RateContent()
        {
            var client = await TestContext.CreateBasicAuthClientAndUser();

            var response = await client.Accounts.RateContent(new RateContentRequest
            {
                ContentData = "a-cool-page",
                Created = DateTime.Now,
                Intent = RatingIntent.Like,
                Type = RatingType.FundraisingPage
            });

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async void GetUserContentRatingHistory()
        {
            var client = await TestContext.CreateBasicAuthClientAndUser();

            await client.Accounts.RateContent(new RateContentRequest
            {
                ContentData = "a-cool-page",
                Created = DateTime.Now,
                Intent = RatingIntent.Like,
                Type = RatingType.FundraisingPage
            });

            var response = await client.Accounts.GetUserContentRatingHistory();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Ratings.Count == 1);
            Assert.That(response.Data.Ratings.First().ContentData == "a-cool-page");
        }

        [Test]
        public async void GetUserContentFeed()
        {
            var client = await TestContext.CreateBasicAuthClientAndUser();

            var response = await client.Accounts.GetContentFeed();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
        }

        [Test]
        public async void InterestsAdd()
        {
            var client = await TestContext.CreateBasicAuthClientAndUser();

            var response = await client.Accounts.InterestsAdd("brewing beer");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async void InterestsGet()
        {
            var client = await TestContext.CreateBasicAuthClientAndUser();

            client.Accounts.InterestsAdd("brewing beer");
            client.Accounts.InterestsAdd("riding bikes");

            var response = await client.Accounts.InterestsGet();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Count, Is.GreaterThan(0));
            Assert.That(response.Data.Contains("brewing beer"));
            Assert.That(response.Data.Contains("riding bikes"));
        }

        [Test]
        public async void InterestsReplace()
        {
            var client = await TestContext.CreateBasicAuthClientAndUser();

            await client.Accounts.InterestsAdd("brewing beer");
            await client.Accounts.InterestsAdd("riding bikes");

            await client.Accounts.InterestsReplace("riding horses", "brewing trouble");

            var response = await client.Accounts.InterestsGet();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Count, Is.GreaterThan(0));
            Assert.That(response.Data.Contains("brewing beer"), Is.False);
            Assert.That(response.Data.Contains("riding bikes"), Is.False);
            Assert.That(response.Data.Contains("riding horses"));
            Assert.That(response.Data.Contains("brewing trouble"));
        }
    }
}
