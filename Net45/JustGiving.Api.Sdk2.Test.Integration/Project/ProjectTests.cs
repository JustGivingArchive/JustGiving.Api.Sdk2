using System.Net;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Project
{
    [TestFixture]
    public class ProjectTests
    {
        [Test]
        public async void CanGetProjectById()
        {
            const int projectId = 1876617;
            var client = TestContext.CreateAnonymousClient();
            var result = await client.Project.GlobalProjectById(projectId);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
