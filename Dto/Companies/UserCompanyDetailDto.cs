using System;
using System.Collections.Generic;
using System.Text;
using Targi.Core.Domain;

namespace Targi.Infrastructure.Dto
{
   public class UserCompanyDetailDto
    {
        public Guid Id {get;set;}
        public string Email { get; set; }
        public CompanyProfileDto CompanyProfile { get; set; }
    }


}
