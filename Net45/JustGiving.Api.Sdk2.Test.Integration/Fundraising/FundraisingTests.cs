using System;
using System.Linq;
using System.Net;
using JustGiving.Api.Sdk2.Model.Fundraising.Request;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Fundraising
{
    [TestFixture]
    public class FundraisingTests
    {
        [Test]
        public async void CanCheckExistingPageName()
        {
            const string pageName = "YouCanTestPage5";
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Fundraising.FundraisingPageUrlCheck(pageName);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async void CanCheckNonExistingPageName()
        {
            var pageName = Guid.NewGuid().ToString();
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Fundraising.FundraisingPageUrlCheck(pageName);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async void CanSuggestNewNameWhenNameExists()
        {
            const string pageName = "YouCanTestPage5";
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Fundraising.SuggestPageShortNames(pageName);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Names.Count, Is.GreaterThan(0));
            Assert.That(response.Data.Names.Any(name => name.Contains(pageName)), Is.True);
        }

        [Test]
        public async void CanSuggestNewNameWhenNameDoesNotExist()
        {
            var pageName = Guid.NewGuid().ToString();
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Fundraising.SuggestPageShortNames(pageName);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Names.Count, Is.GreaterThan(0));
            Assert.That(response.Data.Names.Any(name => name == pageName), Is.True);
        }

        [Test]
        public async void CanRegisterFundraisingPageForActivity()
        {
            var pageName = "Sdk2-test-" + Guid.NewGuid().ToString("N");
            var client = await TestContext.CreateBasicAuthClientAndUser();
            var requst = new FundraisingPageRegistration
            {
                ActivityType = ActivityType.Birthday,
                CharityId = TestContext.DemoCharityId,
                PageShortName = pageName,
                PageTitle = "Sdk2 Test Page",
                EventName = "My Birthday",
                EventDate = DateTime.Now.AddMonths(1).Date
            };

            var response = await client.Fundraising.RegisterFundraisingPage(requst);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async void CanRegisterFundraisingPageForEvent()
        {
            const int eventId = 756550;
            var pageName = "Sdk2-test-" + Guid.NewGuid().ToString("N");
            var client = await TestContext.CreateBasicAuthClientAndUser();
            var requst = new FundraisingPageRegistration
            {
                CharityId = TestContext.DemoCharityId,
                PageShortName = pageName,
                PageTitle = "Sdk2 Test Page",
                EventId = eventId
            };

            var response = await client.Fundraising.RegisterFundraisingPage(requst);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }    

}
