using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command
{
    public class WebinarForUpdate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string WebinarUrl { get; set; }
        public DateTime StartDateOfTheEvent { get; set; }
        public DateTime EndDateOfTheEvent { get; set; }
    }
}
