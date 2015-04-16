using System;
using JustGiving.Api.Sdk2.Model.Account.Request;

namespace JustGiving.Api.Sdk2.Test.Integration.Account
{
    public static class AccountHelper
    {
        public static Registration CreateRegistration(out string username, out string password)
        {
            username = string.Format("integration-test-{0}{1}{2}{3}{4}{5}@justgiving.com", DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            password = Guid.NewGuid().ToString();

            var reg = new Registration
            {
                AcceptTermsAndConditions = true,
                Address = new Address
                {
                    Country = "United Kingdom",
                    CountyOrState = "London",
                    Line1 = "Blue Fin Building",
                    TownOrCity = "London",
                    Line2 = "Southwark Street",
                    PostcodeOrZipcode = "SE1 0TU"
                },
                Email = username,
                FirstName = "Integration",
                LastName = "Tester",
                Password = password,
                Reference = "MY-REF",
                Title = "Ms"

            };

            return reg;
        }
    }
}
