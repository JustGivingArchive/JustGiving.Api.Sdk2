namespace JustGiving.Api.Sdk2.Model.Event.Response
{
    public class EventRegistrationResponse
    {
        public string ContentUri { get; set; }

        public RestResponseNavigationElement Next { get; set; }

        public ErrorResponse Error { get; set; }

        public int Id { get; set; }
    }
}
