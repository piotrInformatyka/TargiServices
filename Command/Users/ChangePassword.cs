using System;
using System.Collections.Generic;
using System.Text;

namespace Targi.Infrastructure.Command.Users
{
    public class ChangePassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
