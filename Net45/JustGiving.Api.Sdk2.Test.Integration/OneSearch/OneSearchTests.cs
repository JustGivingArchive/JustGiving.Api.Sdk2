using System.Net;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.OneSearch
{
    [TestFixture]
    public class OneSearchTests
    {
        [Test]
        public async void CanUseOneSearch()
        {
            var client = TestContext.CreateAnonymousClient();
            var result = await client.OneSearch.OneSearchIndex("migrant rights");
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result.Data.Total, Is.GreaterThan(0));
        }
    }
}
