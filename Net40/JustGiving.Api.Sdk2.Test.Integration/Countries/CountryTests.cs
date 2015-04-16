using System.Net;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Countries
{
    [TestFixture]
    public class CountryTests
    {
        [Test]
        public async void ListCountries()
        {
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Countries.ListCountries();
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.GreaterThan(0));
        }
    }
}
