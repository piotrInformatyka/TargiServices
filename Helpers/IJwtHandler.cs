using System;
using System.Collections.Generic;
using System.Text;
using Targi.Infrastructure.Dto;

namespace Targi.Infrastructure.Helpers
{
    public interface IJwtHandler
    {
        JwtDto CreateTokem(Guid userId, string role, string name);
    }
}
