using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.OneSearch.Response
{
    public class OneSearchResponse
    {
        public List<GroupedResults> GroupedResults { get; set; }

        public string SpecificIndex { get; set; }

        public string Country { get; set; }

        public string Query { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }
    }
}
