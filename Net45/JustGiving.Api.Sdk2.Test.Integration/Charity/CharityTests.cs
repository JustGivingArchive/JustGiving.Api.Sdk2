using System.Net;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Charity
{
    [TestFixture]
    public class CharityTests
    {
        [Test]
        public async void GetCharityById()
        {
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Charities.GetCharityById(TestContext.DemoCharityId);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Name, Is.Not.Null);
            Assert.That(response.Data.Name.Length, Is.GreaterThan(0));
        }

        [Test]
        public async void GetEventsByCharityId()
        {
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Charities.GetEventsByCharityId(TestContext.DemoCharityId);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Events.Count, Is.GreaterThan(0));
        }

        [Test]
        public async void GetCharityDonations()
        {
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Charities.GetCharityDonations(TestContext.DemoCharityId);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.GreaterThan(0));
        }

        [Test]
        public async void GetCharityCategories()
        {
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Charities.GetCharityCategories();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.GreaterThan(0));
        }
    }
}
