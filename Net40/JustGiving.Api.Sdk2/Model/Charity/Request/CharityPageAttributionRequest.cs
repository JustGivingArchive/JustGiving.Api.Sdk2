namespace JustGiving.Api.Sdk2.Model.Charity.Request
{
    public class CharityPageAttributionRequest
    {
        public CharityPageAttributionRequest()
        {
        }

        public CharityPageAttributionRequest(string attribution)
        {
            Attribution = attribution;
        }

        public string Attribution { get; set; }
    }
}
