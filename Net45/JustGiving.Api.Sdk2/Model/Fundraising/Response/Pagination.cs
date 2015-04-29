namespace JustGiving.Api.Sdk2.Model.Fundraising.Response
{
    public class Pagination
    {
        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }

        public int PageSizeRequested { get; set; }

        public int PageSizeReturned { get; set; }
    }
}