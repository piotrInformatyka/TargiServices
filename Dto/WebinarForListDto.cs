using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Dto
{
    public class WebinarForListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string WebinarUrl { get; set; }
        public string BackgroundUrl { get; set; }
        public DateTime StartDateOfTheEvent { get; set; }
        public DateTime EndDateOfTheEvent { get; set; }
        public string CompanyName { get; set; }
        public Guid UserId { get; set; }
    }
}
