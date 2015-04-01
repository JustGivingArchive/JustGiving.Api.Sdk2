using System;

namespace JustGiving.Api.Sdk2.Model.Charity.Response
{
    public class Donation
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime? DonationDate { get; set; }
        public string DonorDisplayName { get; set; }
        public double DonorLocalAmount { get; set; }
        public string DonorLocalCurrencyCode { get; set; }
        public double EstimatedTaxReclaim { get; set; }
        public string ImageUrl { get; set; }
        public string Message { get; set; }
    }
}
