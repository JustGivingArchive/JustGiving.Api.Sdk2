namespace JustGiving.Api.Sdk2.Model.Account.Request
{
    public class AddInterestRequest
    {
        public AddInterestRequest()
        {
        }

        public AddInterestRequest(string interest)
        {
            this.Interest = interest;
        }

        public string Interest { get; set; }
    }
}
