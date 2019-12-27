using aspnetzabota.Admin.Datamodel.Tokens;
using aspnetzabota.Admin.Forms.Login;
using aspnetzabota.Common.Result;
using System.Threading.Tasks;

namespace aspnetzabota.Admin.Services.Login
{
    public interface ILoginService
        {
            Task<ZabotaResult<Jwt>> Login(LoginForm form);
            Task<ZabotaResult<bool>> Logout(LogoutForm form);
        }
}
