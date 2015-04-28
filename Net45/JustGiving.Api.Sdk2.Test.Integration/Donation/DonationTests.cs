using System.Linq;
using System.Net;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Donation
{
    [TestFixture]
    public class DonationTests
    {
        [Test]
        [Ignore("Bug in API mapping of Donation ID")]
        public async void CanGetDonationById()
        {
            const int donationId = 35508049;
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Donation.RetrieveDonationDetails(donationId);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.DonationId, Is.EqualTo(donationId));
        }

        [Test]
        public async void CanGetDonationByReference()
        {
            const string reference = "1";
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Donation.RetrieveDonationDetailsByReference(reference);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Donations.Count, Is.GreaterThan(1));
            Assert.That(response.Data.Donations.First().ThirdPartyReference, Is.EqualTo(reference));
        }

        [Test]
        public async void CanGetDonationStatus()
        {
            const int donationId = 35508049;
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Donation.RetrieveDonationStatus(donationId);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.DonationId, Is.EqualTo(donationId));
            Assert.That(response.Data.Status, Is.EqualTo("Accepted"));
        }
    }
}
