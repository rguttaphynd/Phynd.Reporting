using Microsoft.AspNetCore.Http;
using Phynd.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phynd.Reporting.Api
{
    public class GetToken
    {
        private readonly RequestDelegate _next;

        public GetToken(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["PhyndUserContext"] = new PhyndUserContext()
            {
                IsExternalRequest = true,
                UserHealthSystemID = 1,
                TargetHealthSystemID = 33,
                UserID = 1,
                UserName = "Craig"
            };

            await this._next.Invoke(context).ConfigureAwait(false);
            
        }
    }
}
