using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetzabota.Web.Common.Filters
{
    public class IdentityStorageFilterAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                await next();
                return;
            }

            var service = context.HttpContext.RequestServices.GetService<IIdentityRequestStorage>();
            var tokenIdClaim = context.HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier);
            int.TryParse(tokenIdClaim.Value, out int tokenId);

            var token = await service.Ensure(tokenId);
            if (token == null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
            else
                await next();
        }
    }
}