using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command.Companies
{
    public class CompanyForUpdate
    {
        public string CompanyName { get; set; }
        public string WebsiteUrl { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public ICollection<SocialForUpdate> Socials { get; set; }
        public ICollection<BenefitCardForUpdate> BenefitCards { get; set; }

    }
    public class SocialForUpdate
    {
        public Guid Id { get; set; }
        public string Name;
        public string Url;
    }
    public class BenefitCardForUpdate
    {
        public Guid Id { get; set; }
        public string Name;
        public string[] Description;
    }
}
