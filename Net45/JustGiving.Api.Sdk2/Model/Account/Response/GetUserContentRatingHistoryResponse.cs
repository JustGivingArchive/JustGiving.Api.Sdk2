using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Account.Response
{
    public class GetUserContentRatingHistoryResponse
    {
        public List<Rating> Ratings { get; set; }
        public Pagination Pagination { get; set; }
    }
}
