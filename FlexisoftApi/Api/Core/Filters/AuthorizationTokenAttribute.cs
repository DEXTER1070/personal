using Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace Infomil.Flexisoft.Flexisoft.FlexisoftApi.Api.Core.Filters
{
    public sealed class AuthorizationTokenAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;

            var apiConfiguration = context.HttpContext.RequestServices.GetService(typeof(IOptions<ApiConfiguration>)) as IOptions<ApiConfiguration>;

            if (!request.Headers.TryGetValue(FlexisoftApi.Contracts.Constants.Environment.AuhtorizationTokenVariableName, out StringValues values) || !values.Contains(apiConfiguration.Value.ApiSecret))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
