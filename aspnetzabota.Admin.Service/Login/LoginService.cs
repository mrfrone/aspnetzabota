﻿using System;
using System.Threading.Tasks;
using aspnetzabota.Admin.Database.Entities;
using aspnetzabota.Admin.Database.Repository.Identities;
using aspnetzabota.Admin.Database.Repository.Tokens;
using aspnetzabota.Admin.Datamodel.Tokens;
using aspnetzabota.Admin.Forms.Login;
using aspnetzabota.Common.PasswordService.JwtGenerate;
using aspnetzabota.Common.PasswordService.PasswordHash;
using AutoMapper;

namespace aspnetzabota.Admin.Services.Login
{
    internal class LoginService : ILoginService
    {
        private readonly IIdentitiesRepository _identitiesRepository;
        private readonly ITokensRepository _tokensRepository;
        private readonly IPasswordHashCalculator _passwordHashCalculator;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;

        public LoginService(IIdentitiesRepository identitiesRepository,
            ITokensRepository tokensRepository,
            IPasswordHashCalculator passwordHashCalculator,
            IJwtGenerator jwtGenerator,
            IMapper mapper)
        {
            _identitiesRepository = identitiesRepository;
            _tokensRepository = tokensRepository;
            _passwordHashCalculator = passwordHashCalculator;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }
        public async Task<Jwt> Login(LoginForm form)
        {
            var identity = await _identitiesRepository.GetByLoginAndPassword(form);
            if (identity == null)
                return null;

            var hashed = _passwordHashCalculator.Calc(form.Password);
            if (identity.Password != hashed)
                return null;

            var token = await _tokensRepository.IssueToken(identity.Id, DateTimeOffset.UtcNow.AddYears(1));
            if (token == null)
                return null;

            var mappedToken = _mapper.Map<Jwts, Jwt>(token);

            var tokenBody = _jwtGenerator.Generate(mappedToken);
            await _tokensRepository.WriteBody(tokenBody.Id, tokenBody.Token);

            return tokenBody;

        }

        public async Task<bool> Logout(LogoutForm form)
        {
            var token = await _tokensRepository.GetById(form.TokenId);
            if (token == null)
                return false;

            var result = await _tokensRepository.RevokeByTokenId(form.ActorId, form.TokenId);

            return result;
        }
    }
}