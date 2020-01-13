using aspnetzabota.Admin.Forms.Login;
using aspnetzabota.Admin.Services.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using aspnetzabota.Common.Result;
using aspnetzabota.Web.Common;
using aspnetzabota.Web.Common.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;

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
        [Authorize]
        public ViewResult Main()
        {
            return View();
        }
        [ValidModelState]
        public async Task<IActionResult> LoginPost([FromBody]LoginForm form)
        {
            var result = await _loginService.Login(new LoginForm
            {
                Login = form.Login,
                Password = form.Password
            });

            if (result.IsCorrect)
                HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", result.Result.Token);

            //new CookieOptions
            //{
            //    MaxAge = TimeSpan.FromMinutes(60)
            //});

            return ZabotaResult(result.IsCorrect);
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

            if (result.IsCorrect)
                HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");

            return ZabotaResult(result);
        }
    }
}