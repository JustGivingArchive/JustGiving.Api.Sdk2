using System.Net;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Search
{
    [TestFixture]
    public class SearchTests
    {
        [Test]
        [Ignore("Error 500")]
        public async void CanSearchCharities()
        {
            var client = TestContext.CreateAnonymousClient();
            var result = await client.Search.CharitySearch("migrant rights");
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
