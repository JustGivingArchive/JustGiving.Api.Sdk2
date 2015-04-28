using System;

namespace JustGiving.Api.Sdk2.Model.Event.Response
{
    public class InMemoryPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
    }
}