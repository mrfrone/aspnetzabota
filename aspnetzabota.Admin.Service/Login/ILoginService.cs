using aspnetzabota.Admin.Datamodel.Tokens;
using aspnetzabota.Admin.Forms.Login;
using System.Threading.Tasks;

namespace aspnetzabota.Admin.Services.Login
{
    public interface ILoginService
        {
            Task<Jwt> Login(LoginForm form);
            Task<bool> Logout(LogoutForm form);
        }
}
