﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;

namespace Phynd.Reporting.Api.Authentication
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "custom auth";
        public string Scheme => DefaultScheme;
        public StringValues AuthKey { get; set; }
    }
}
