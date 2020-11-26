using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command
{
    public class PhotoForCreation
    {
        public IFormFile File { get; set; }
        public string Description { get; set; }
    }
}
