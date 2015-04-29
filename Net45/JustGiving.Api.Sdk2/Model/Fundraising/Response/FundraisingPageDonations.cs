using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGiving.Api.Sdk2.Model.Fundraising.Response
{
    public class FundraisingPageDonations
    {
        public List<FundraisingPageDonation> Donations { get; set; }

        public Pagination Pagination { get; set; }

        public string PageShortUrl { get; set; }
    }
}
