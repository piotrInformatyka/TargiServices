using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Dto
{
    public class TokenDto
    {
        public string Token { get; set; }
        public long Expires { get; set; }
        public string Role { get; set; }
        public string LogoUrl { get; set; }
        public bool IsCompany { get; set; }
    }
}
