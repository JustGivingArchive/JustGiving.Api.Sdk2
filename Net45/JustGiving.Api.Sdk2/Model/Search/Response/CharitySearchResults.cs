using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Search.Response
{
    public class CharitySearchResults
    {
        public string Query { get; set; }

        public int NumberOfHits { get; set; }

        public int TotalPages { get; set; }

        public RestResponseNavigationElement SugguestedQuery { get; set; }

        public RestResponseNavigationElement Prev { get; set; }

        public RestResponseNavigationElement Next { get; set; }

        public List<CharitySearchResult> Results { get; set; }
    }
}
