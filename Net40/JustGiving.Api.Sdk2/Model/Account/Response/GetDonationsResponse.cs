using System;
using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Account.Response
{
    public class GetDonationsResponse
    {
        public List<Donation> Donations { get; set; }
        public Charity Charity { get; set; }
    }

    public class Charity
    {
        public int Id { get; set; }
        public string LogoAbsoluteUrl { get; set; }
        public string LogoUrl { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }

    public class Donation
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime DonationDate { get; set; }
        public string DonationRef { get; set; }
        public string DonorDisplayName { get; set; }
        public double DonorLocalAmount { get; set; }
        public string DonorLocalCurrencyCode { get; set; }
        public double EstimatedTaxReclaim { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public string ThirdPartyReference { get; set; }
        public int CharityId { get; set; }
        public string CharityName { get; set; }
        public string LogoAbsoluteUrl { get; set; }
        public List<KeyValue> OwnerProfileImageUrls { get; set; }
        public string PageOwnerName { get; set; }
        public string PageShortName { get; set; }
        public string PageTitle { get; set; }
        public string PaymentType { get; set; }
    }
}