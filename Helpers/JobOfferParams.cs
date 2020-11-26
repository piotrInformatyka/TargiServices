using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Helpers
{
    public class JobOfferParams
    {
        private const int MaxPageSize = 32;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 16;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string JobOfferName { get; set; }
        public string Category { get; set; }

    }
}
