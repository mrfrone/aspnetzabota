using aspnetzabota.Admin.Forms.Login;
using aspnetzabota.Admin.Services.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Common.Result;
using aspnetzabota.Web.Common;
using aspnetzabota.Web.Common.Filters;
using Microsoft.AspNetCore.Authorization;

namespace aspnetzabota.Controllers
{
    public class AdminController : BaseController
    {
        private readonly ILoginService _loginService;

        public AdminController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public ViewResult Login()
        {
            return View();
        }
        [ValidModelState]
        public async Task<IActionResult> Login([FromBody]LoginForm form)
        {
            var result = await _loginService.Login(new aspnetzabota.Admin.Forms.Login.LoginForm
            {
                Login = form.Login,
                Password = form.Password
            });

            return ZabotaResult(result);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var form = new LogoutForm
            {
                ActorId = CurrentIdentity.Id,
                TokenId = CurrentTokenId
            };
            var result = await _loginService.Logout(form);

            return ZabotaResult(result);
        }
    }
}