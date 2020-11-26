using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command.Users
{
    public class AcceptCompany
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string DayOfParticipation { get; set; }
        public string CompanyStatus { get; set; }
    }
}
