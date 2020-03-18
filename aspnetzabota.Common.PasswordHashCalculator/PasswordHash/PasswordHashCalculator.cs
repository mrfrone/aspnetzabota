using System.Security.Cryptography;
using System.Text;
using aspnetzabota.Common.Datamodel.PasswordHashing;
using Microsoft.Extensions.Options;

namespace aspnetzabota.Common.PasswordService.PasswordHash
{
    internal class PasswordHashCalculator : IPasswordHashCalculator
    {
        private readonly IOptionsMonitor<PasswordHashingSettings> _settings;

        public PasswordHashCalculator(IOptionsMonitor<PasswordHashingSettings> settings)
        {
            _settings = settings;
        }

        public string Calc(string src)
        {
            Encoding unicode = Encoding.Unicode;
            byte[] bytes1 = unicode.GetBytes(Salt);
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(src, bytes1))
            {
                byte[] bytes2 = rfc2898DeriveBytes.GetBytes(60);
                return unicode.GetString(bytes2);
            }
        }

        private string Salt
        {
            get
            {
                return _settings.CurrentValue.Salt;
            }
        }
    }
}