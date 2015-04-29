using System;

namespace JustGiving.Api.Sdk2.Model.Fundraising.Request
{
    public class RememberedPerson
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Town { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }
    }
}