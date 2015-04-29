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

        [Test]
        public async void CanGetFundraisingPageDetails()
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

            await client.Fundraising.RegisterFundraisingPage(requst);
            var response = await client.Fundraising.GetFundraisingPageDetails(pageName);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.PageShortName, Is.EqualTo(pageName));
        }

        [Test]
        public async void CanGetFundraisingPagesForUser()
        {
            const int eventId = 756550;
            var pageName1 = "Sdk2-test-" + Guid.NewGuid().ToString("N");
            var client = await TestContext.CreateBasicAuthClientAndUser();
            var request = new FundraisingPageRegistration
            {
                CharityId = TestContext.DemoCharityId,
                PageShortName = pageName1,
                PageTitle = "Sdk2 Test Page",
                EventId = eventId
            };

            await client.Fundraising.RegisterFundraisingPage(request);
            var pageName2 = "Sdk2-test-" + Guid.NewGuid().ToString("N");

            request = new FundraisingPageRegistration
            {
                CharityId = TestContext.DemoCharityId,
                PageShortName = pageName2,
                PageTitle = "Sdk2 Test Page",
                EventId = eventId
            };

            await client.Fundraising.RegisterFundraisingPage(request);

            var response = await client.Fundraising.GetFundraisingPages();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Count, Is.EqualTo(2));
            Assert.That(response.Data.Any(frp => frp.PageShortName == pageName1));
            Assert.That(response.Data.Any(frp => frp.PageShortName == pageName2));
        }

        [Test]
        public async void CanGetDonationsForPage()
        {
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Fundraising.GetFundraisingPageDonations(TestContext.PageWithDonations);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Donations.Count, Is.GreaterThan(0));
            Assert.That(response.Data.Pagination.TotalResults, Is.GreaterThan(0));
        }

        [Test]
        public async void CanUpdateFundraisingPage()
        {
            const int eventId = 756550;
            var pageName = "Sdk2-test-" + Guid.NewGuid().ToString("N");
            var client = await TestContext.CreateBasicAuthClientAndUser();
            var frpRequest = new FundraisingPageRegistration
            {
                CharityId = TestContext.DemoCharityId,
                PageShortName = pageName,
                PageTitle = "Sdk2 Test Page",
                EventId = eventId
            };

            await client.Fundraising.RegisterFundraisingPage(frpRequest);

            var storySupplement = "Hello, world " + DateTime.Now;
            var update = new FundraisingPageUpdate() {StorySupplement = storySupplement};
            var response = await client.Fundraising.UpdateFundraisingPage(pageName, update);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async void CanPostMicroblogUpdates()
        {
            const int eventId = 756550;
            var pageName = "Sdk2-test-" + Guid.NewGuid().ToString("N");
            var client = await TestContext.CreateBasicAuthClientAndUser();
            var frpRequest = new FundraisingPageRegistration
            {
                CharityId = TestContext.DemoCharityId,
                PageShortName = pageName,
                PageTitle = "Sdk2 Test Page",
                EventId = eventId
            };

            await client.Fundraising.RegisterFundraisingPage(frpRequest);

            var update = new Model.Fundraising.Request.MicroblogUpdate()
            {
                CreatedDate = DateTime.Now,
                Message = "Hello world " + DateTime.Now
            };

            var response = await client.Fundraising.PageUpdatesAddPost(pageName, update);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async void CanGetMicroblogUpdates()
        {
            const int eventId = 756550;
            var pageName = "Sdk2-test-" + Guid.NewGuid().ToString("N");
            var client = await TestContext.CreateBasicAuthClientAndUser();
            var frpRequest = new FundraisingPageRegistration
            {
                CharityId = TestContext.DemoCharityId,
                PageShortName = pageName,
                PageTitle = "Sdk2 Test Page",
                EventId = eventId
            };

            await client.Fundraising.RegisterFundraisingPage(frpRequest);

            var update = new Model.Fundraising.Request.MicroblogUpdate()
            {
                CreatedDate = DateTime.Now,
                Message = "Hello world " + DateTime.Now
            };

            await client.Fundraising.PageUpdatesAddPost(pageName, update);

            var response = await client.Fundraising.PageUpdates(pageName);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Count, Is.EqualTo(1));
        }

        [Test]
        public async void CanGetMicroblogUpdatesById()
        {
            const int eventId = 756550;
            var pageName = "Sdk2-test-" + Guid.NewGuid().ToString("N");
            var client = await TestContext.CreateBasicAuthClientAndUser();
            var frpRequest = new FundraisingPageRegistration
            {
                CharityId = TestContext.DemoCharityId,
                PageShortName = pageName,
                PageTitle = "Sdk2 Test Page",
                EventId = eventId
            };

            await client.Fundraising.RegisterFundraisingPage(frpRequest);

            var update = new Model.Fundraising.Request.MicroblogUpdate()
            {
                CreatedDate = DateTime.Now,
                Message = "Hello world " + DateTime.Now
            };

            await client.Fundraising.PageUpdatesAddPost(pageName, update);

            var getAllResponse = await client.Fundraising.PageUpdates(pageName);
            var postId = getAllResponse.Data.First().Id;

            var response = await client.Fundraising.PageUpdateById(pageName, postId);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Id, Is.EqualTo(postId));
        }
    }    

}
