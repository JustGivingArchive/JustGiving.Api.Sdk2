using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Fundraising.Response
{
    public class FundraisingPageMedia
    {
        public List<FundraisingPageImage> Images { get; set; }

        public List<FundraisingPageVideo> Videos { get; set; }
    }
}