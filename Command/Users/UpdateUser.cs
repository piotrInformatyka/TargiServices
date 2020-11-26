using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command.Users
{
    public class UpdateUser
    {
        public string CompanyName { get; set; }
        public string CompanyStatus { get; set; }
        public string PhoneNumber { get; set; }
        public string DayOfParticipation { get; set; }
        public string ContactPerson { get; set; }
        public int MaxJobOffers { get; set; }

    }
}
