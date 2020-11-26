using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command
{
    public class PhotoForUpdate
    {
        Guid Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
