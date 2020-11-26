using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Dto
{
    public class JobOfferForListDto
    {
        public string Id {get;set;}
        public string UserId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int WageLow { get; set; }
        public int WageHigh { get; set; }
        public string LogoUrl { get; set; }
        public string CompanyName { get; set; }
        public string Url { get; set; }
        public string ColorText { get; set; }
        public string ColorBackground { get; set; }
    }
}
