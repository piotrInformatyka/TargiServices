using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Dto.Companies
{
    public class CompanyProfileForListModeratorDto
    {
        public string CompanyName { get; set; }
        public string LogoUrl { get; set; }
        public string CompanyStatus { get; set; }
        public string DayOfParticipation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }
        public int MaxJobOffers { get; set; }
        public Guid UserId { get; set; }
    }
}
