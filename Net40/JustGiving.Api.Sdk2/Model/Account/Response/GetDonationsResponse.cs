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
        int Id { get; set; }
        string Image { get; set; }
        string Message { get; set; }
        string Source { get; set; }
        string Status { get; set; }
        string ThirdPartyReference { get; set; }
        int CharityId { get; set; }
        string CharityName { get; set; }
        string LogoAbsoluteUrl { get; set; }
        List<KeyValue> OwnerProfileImageUrls { get; set; }
        string PageOwnerName { get; set; }
        string PageShortName { get; set; }
        string PageTitle { get; set; }
        string PaymentType { get; set; }
    }
}