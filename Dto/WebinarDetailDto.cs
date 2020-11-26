using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Dto
{
    public class WebinarDetailDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string WebinarUrl { get; set; }
        public DateTime StartDateOfTheEvent { get; set; }
        public DateTime EndDateOfTheEvent { get; set; }
        public string CompanyName { get; set; }
        public Guid UserId { get; set; }
        public string LogoCompanyUrl { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
