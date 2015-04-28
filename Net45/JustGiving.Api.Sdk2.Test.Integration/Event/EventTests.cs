using System;
using System.Net;
using JustGiving.Api.Sdk2.Clients.Event;
using JustGiving.Api.Sdk2.Model.Event.Request;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Event
{
    [TestFixture]
    public class EventTests
    {
        [Test]
        public async void CanGetEventById()
        {
            const int eventId = 756550;
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Event.GetEventById(eventId);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Id, Is.EqualTo(eventId));
        }

        [Test]
        public async void CanGetPagesForEvent()
        {
            const int eventId = 756550;
            var client = TestContext.CreateAnonymousClient();
            var response = await client.Event.GetPagesForEvent(eventId);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.TotalPages, Is.GreaterThan(1));
        }

        [Test]
        public async void CanRegisterEvent()
        {
            var client = TestContext.CreateAnonymousClient();
            var ev = new EventRegistration
            {
                CompletionDate = DateTime.Now.AddDays(7),
                Description = "Integration test event registration",
                EventType = EventTypes.Christmas,
                ExpiryDate = DateTime.Now.AddYears(1),
                Name = "Test Event",
                StartDate = DateTime.Now.AddDays(1)
            };
            var response = await client.Event.RegisterEvent(ev);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}
