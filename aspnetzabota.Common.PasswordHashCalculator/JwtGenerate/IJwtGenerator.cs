using aspnetzabota.Admin.Datamodel.Tokens;

namespace aspnetzabota.Common.PasswordService.JwtGenerate
{
    public interface IJwtGenerator
    {
        Jwt Generate(Jwt source);
    }
}