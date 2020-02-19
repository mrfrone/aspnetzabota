using Microsoft.AspNetCore.Mvc;
using aspnetzabota.Web.ViewModels;
using aspnetzabota.Admin.Services.Identities;
using System.Net;
using System.Linq;
using System.Security.Claims;

namespace aspnetzabota.Web.Components
{
    public class AdminMenu : ViewComponent
    {
        private readonly IIdentityService _identityService;

        public AdminMenu(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public IViewComponentResult Invoke()
        {
            var result = new AdminMenuViewModel
            {
                Identity = _identityService.GetIdentityByTokenId(CurrentTokenId).Result
            };
            if(result.Identity.IsCorrect)
                return View(result);
            else
                return View(HttpStatusCode.Unauthorized);
        }
        private int CurrentTokenId
        {
            get
            {
                var tokenIdClaim = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier);
                int.TryParse(tokenIdClaim.Value, out int tokenId);

                return tokenId;
            }
        }
    }
}
