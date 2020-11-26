using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command.JobOffers
{
    public class JobOfferForUpdate
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int WageLow { get; set; }
        public int WageHigh { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ColorText { get; set; }
        public string ColorBackground { get; set; }
    }
}
