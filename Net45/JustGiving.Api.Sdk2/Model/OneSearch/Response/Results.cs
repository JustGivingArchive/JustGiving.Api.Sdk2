using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.OneSearch.Response
{
    public class Results
    {
        public List<int> EventIds { get; set; }

        public string Subtext { get; set; }

        public string Link { get; set; }

        public string LinkPath { get; set; }

        public string CountryCode { get; set; }

        public string ProfileWhat { get; set; }

        public string ProfileWhy { get; set; }

        public string Highlight { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }

        public string Type { get; set; }

        public double Score { get; set; }
    }
}