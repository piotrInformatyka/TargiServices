using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Dto
{
    public class CompanyForAcceptDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactPerson { get; set; }
    }
}
