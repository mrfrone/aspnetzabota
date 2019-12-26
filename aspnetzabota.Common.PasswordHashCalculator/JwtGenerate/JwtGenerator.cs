using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using aspnetzabota.Admin.Datamodel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace aspnetzabota.Common.PasswordService.JwtGenerate
{
    internal class JwtGenerator : IJwtGenerator, IDisposable
    {
        private readonly IOptionsMonitor<JwtSettings> _options;
        private IDisposable _changeDisposable;
        private SigningCredentials _signingSecurityKey;

        public JwtGenerator(IOptionsMonitor<JwtSettings> options)
        {
            _options = options;
            _changeDisposable = _options.OnChange(HandleChange);
            RefreshKey(_options.CurrentValue);
        }

        public Jwt Generate(Jwt source)
        {
            return new Jwt
            {
                Id = source.Id,
                Expires = source.Expires,
                Token = GetJwtSecurityToken(source.Expires, source.Id)
            };
        }

        private string GetJwtSecurityToken(DateTimeOffset dateExpires, int id)
        {
            var token = new JwtSecurityToken(
                issuer: _options.CurrentValue.Issuer,
                audience: _options.CurrentValue.Audience,
                claims: GetClaims(id),
                expires: dateExpires.Date,
                signingCredentials: _signingSecurityKey);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> GetClaims(int id)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };
        }

        private void HandleChange(JwtSettings sets)
        {
            RefreshKey(sets);
        }

        private void RefreshKey(JwtSettings sets)
        {
            _signingSecurityKey = new SigningCredentials(sets.GetSecurityKey(), SecurityAlgorithms.HmacSha256);
        }

        #region Disposable implementation

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_changeDisposable != null)
                {
                    _changeDisposable.Dispose();
                    _changeDisposable = null;
                }
            }

            _disposed = true;
        }

        #endregion
    }
}