using System.Linq;
using System.Security.Claims;
using aspnetzabota.Admin.Datamodel.Identities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetzabota.Web.Common
{
    public class BaseController : Controller
    {
        protected int CurrentTokenId
        {
            get
            {
                var tokenIdClaim = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier);
                int.TryParse(tokenIdClaim.Value, out int tokenId);

                return tokenId;
            }
        }

        protected ZabotaIdentity CurrentIdentity
        {
            get
            {
                var service = HttpContext.RequestServices.GetService<IIdentityRequestStorage>();
                return service.Current;
            }
        }
    }
}