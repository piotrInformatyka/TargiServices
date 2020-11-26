using System;
using System.Collections.Generic;
using System.Text;
using Targi.Core.Domain;

namespace Targi.Infrastructure.Dto
{
    public class CompanyProfileDto
    {
        public string CompanyName { get; set; }
        public string CompanyStatus { get; set; }
        public string WebsiteUrl { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<BenefitCardDto> BenefitCards { get; set; }
        public ICollection<SocialDto> Socials { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
    public class SocialDto
    {
        public string Name;
        public string Url;
    }
    public class BenefitCardDto
    {
        public string Name;
        public string[] Description;
    }
}
