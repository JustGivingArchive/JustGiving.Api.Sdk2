namespace JustGiving.Api.Sdk2.Model.Account.Request
{
    public class Registration
    {
        /// <summary>
        /// Your reference (Optional).
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// The user's title for example Mr (Required).
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The user's firstName (Required).
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The user's lastName (Required).
        /// </summary>
        public string LastName { get; set; }

        public Address Address { get; set; }
        /// <summary>
        /// The user's email (Required).
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The user's password (Required).
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// A Boolean indicating whether user accepts JustGiving's Terms and conditions. Note providing false will fail validation (Required).
        /// </summary>
        public bool AcceptTermsAndConditions { get; set; }

        public Registration()
        {
            Address = new Address();
        }
    }
    public class Address
    {
        /// <summary>
        /// The first line of the of the address where the user resides (Required).
        /// </summary>
        public string Line1 { get; set; }
        /// <summary>
        /// The second line of the of the address where the user resides (Optional).
        /// </summary>
        public string Line2 { get; set; }
        /// <summary>
        /// The town or city where the user resides (Required).
        /// </summary>
        public string TownOrCity { get; set; }
        /// <summary>
        /// The county or state where the user resides (Required).
        /// </summary>
        public string CountyOrState { get; set; }
        /// <summary>
        /// The country where the user resides (Required).
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// The postcode or zip of the address where the user resides (Required).
        /// </summary>
        public string PostcodeOrZipcode { get; set; }
    }
}
