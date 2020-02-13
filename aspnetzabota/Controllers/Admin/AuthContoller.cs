using aspnetzabota.Admin.Forms.Login;
using aspnetzabota.Admin.Services.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Web.Common;
using aspnetzabota.Web.Common.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace aspnetzabota.Controllers
{
    [Route("admin/[controller]/[action]")]
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }

        [ValidModelState]
        [AllowAnonymous]
        public async Task<IActionResult> LoginPost([FromBody]LoginForm form)
        {
            var result = await _loginService.Login(new LoginForm
            {
                Login = form.Login,
                Password = form.Password
            });

            if (result.IsCorrect)
                HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", result.Result.Token);
            

            return ZabotaResult(result.IsCorrect);
        }
        public async Task<IActionResult> Logout()
        {
            var form = new LogoutForm
            {
                ActorId = CurrentIdentity.Id,
                TokenId = CurrentTokenId
            };
            var result = await _loginService.Logout(form);

            if (result.IsCorrect)
                HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");

            return ZabotaResult(result.IsCorrect);
        }
    }
}