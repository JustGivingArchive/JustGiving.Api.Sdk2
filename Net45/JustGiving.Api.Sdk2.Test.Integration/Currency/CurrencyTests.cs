using System.Linq;
using NUnit.Framework;

namespace JustGiving.Api.Sdk2.Test.Integration.Currency
{
    [TestFixture]
    public class CurrencyTests
    {
        [Test]
        public async void CanListCurrencies()
        {
            var client = TestContext.CreateAnonymousClient();
            var currencies = await client.Currency.GetValidCurrencyCodes();
            Assert.That(currencies.Data.Count, Is.GreaterThan(0));
        }

        [Test]
        public async void ContainsSomeExpectedValues()
        {
            var client = TestContext.CreateAnonymousClient();
            var currencies = await client.Currency.GetValidCurrencyCodes();
            Assert.That(currencies.Data.Any(c => c.CurrencyCode == "GBP"), Is.True);
            Assert.That(currencies.Data.Any(c => c.CurrencyCode == "AUD"), Is.True);
            Assert.That(currencies.Data.Any(c => c.CurrencyCode == "USD"), Is.True);
            Assert.That(currencies.Data.Any(c => c.CurrencyCode == "EUR"), Is.True);
        }
    }
}
