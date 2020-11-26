using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command.Users
{
    public class Register
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
