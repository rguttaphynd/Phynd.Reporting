using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phynd.Reporting.Api
{
    public static class GetTokenExtension
    {
        public static IApplicationBuilder UseGetToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GetToken>();
        }
    }

}
