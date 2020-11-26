using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command.Companies
{
    public class AddJobOffer
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int WageLow { get; set; }
        public int WageHigh { get; set; }
        public string Description { get; set; }
    }
}
