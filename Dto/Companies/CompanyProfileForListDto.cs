using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Dto.Companies
{
    public class CompanyProfileForListDto
    {
        public string CompanyName { get; set; }
        public string LogoUrl { get; set; }
        public string BackgroundUrl { get; set; }
        public Guid UserId { get; set; }
    }
}
