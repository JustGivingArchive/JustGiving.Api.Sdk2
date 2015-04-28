namespace JustGiving.Api.Sdk2.Model.Donation.Response
{
    public class DonationStatus
    {
        public string Reference { get; set; }

        public int DonationId { get; set; }

        public string DonationRef { get; set; }

        public string Status { get; set; }

        public decimal Amount { get; set; }
    }
}