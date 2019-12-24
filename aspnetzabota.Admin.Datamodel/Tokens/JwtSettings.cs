using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace aspnetzabota.Admin.Datamodel.Tokens
{
    public class JwtSettings
    {
        public string Issuer { get; set; } // издатель токена
        public string Audience { get; set; } // потребитель токена
        public  string SecurityKey { get; set; }   // ключ для шифрации
        public const int LIFETIME = 60; // время жизни токена - 60 минут

        private SymmetricSecurityKey _symmetricSecurityKey;
        public SymmetricSecurityKey GetSecurityKey()
        {
            if (_symmetricSecurityKey != null)
                return _symmetricSecurityKey;

            return _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecurityKey));
        }
    }
}
