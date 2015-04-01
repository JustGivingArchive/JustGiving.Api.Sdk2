namespace JustGiving.Api.Sdk2.Model.Account.Response
{
    public class Account
    {
        public int ActivePageCount { get; set; }

        public int CompletedPagesCount { get; set; }

        public string Email { get; set; }

        public decimal TotalDonated { get; set; }

        public decimal TotalDonatedGiftAid { get; set; }

        public decimal TotalGiftAid { get; set; }

        public decimal TotalRaised { get; set; }

        public int InMemoryPagesCount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
