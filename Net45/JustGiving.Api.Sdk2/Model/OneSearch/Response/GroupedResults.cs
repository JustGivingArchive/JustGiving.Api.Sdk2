using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.OneSearch.Response
{
    public class GroupedResults
    {
        public string Title { get; set; }

        public int Count { get; set; }

        public List<Results> Results { get; set; }

        public string Specific { get; set; }
    }
}