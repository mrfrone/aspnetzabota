using aspnetzabota.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Web.Common;
using Microsoft.AspNetCore.Authorization;
using aspnetzabota.Admin.Services.Identities;
using aspnetzabota.Admin.Forms.Login;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class IdentitySettingsController : BaseController
    {
        private readonly IIdentityService _identityService;
        public IdentitySettingsController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<ViewResult> List()
        {
            var result = new IdentitySettingsViewModel 
            { 
                Identities = await _identityService.GetIdentities(),
                CurrentIdentity = CurrentIdentity
            };
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddIdentity([FromBody] LoginForm form)
        {
            var result = await _identityService.AddIdentity(form);
            return ZabotaResult(result.IsCorrect);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteIdentity(int id)
        {
            await _identityService.DeleteIdentity(id, CurrentIdentity.Id);
            return Redirect("/admin/IdentitySettings/" + nameof(List));
        }
    }
}