using aspnetzabota.Admin.Database.Context;
using aspnetzabota.Admin.Database.Repository.Tokens;
using aspnetzabota.Admin.Forms.Login;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using aspnetzabota.Common.PasswordService.PasswordHash;
using System;
using aspnetzabota.Common.Result.ErrorCodes;
using aspnetzabota.Common.Result;
using Z.EntityFramework.Plus;

namespace aspnetzabota.Admin.Database.Repository.Identities
{
    class IdentitiesRepository : IIdentitiesRepository
    {
        private readonly AdminContext _ac;
        private readonly ITokensRepository _tokensRepository;
        private readonly IPasswordHashCalculator _passwordHashCalculator;
        private object actorId;

        public IdentitiesRepository(AdminContext ac, ITokensRepository tokensRepository, IPasswordHashCalculator passwordHashCalculator)
        {
            _ac = ac;
            _tokensRepository = tokensRepository;
            _passwordHashCalculator = passwordHashCalculator;
        }
        public async Task<Entities.Identities[]> Get()
        {
            return await _ac.Identities
                .Where(x => x.IsDeleted != true)
                .ToArrayAsync();
        }
        public async Task<Entities.Identities> IdentityByTokenId(int id)
        {
            var jwt = await _tokensRepository.GetById(id);
            if (jwt == null || jwt.IsDeleted)
                return null;

            return await _ac.Identities.FirstOrDefaultAsync(u => u.Id == jwt.IdentityId && u.IsDeleted != true);
        }
        public async Task<Entities.Identities> IdentityByLogin(string login)
        {
            return await _ac.Identities
                .FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<Entities.Identities> GetByLoginAndPassword(LoginForm form)
        {
            var login = form.Login.Trim();

            var user = await _ac.Identities.FirstOrDefaultAsync(u => u.Login == login && u.IsDeleted != true);

            return user;
        }
        public Task<bool> IdentityExistsAsync(int identityId)
        {
            return _ac.Identities.AnyAsync(u => u.Id == identityId && u.IsDeleted != true);
        }
        public Task Add(LoginForm form)
        {
            _ac.Identities.Add(new Entities.Identities
            {
                Login = form.Login,
                Password = _passwordHashCalculator.Calc(form.Password),
                IsDeleted = false
            });

            return _ac.SaveChangesAsync();
        }
        public async Task<ZabotaResult> Delete(int identityId, int actorId)
        {
            var identity = await _ac.Identities.FirstOrDefaultAsync(u => u.Id == identityId && u.IsDeleted != true);
            if (identity == null)
                return ZabotaErrorCodes.CannotFindUserProfileByIdentityId;

            _ac.Identities
                .AsQueryable()
                .Where(r => r.Id == identityId)
                .Update(r => new Entities.Identities 
                {
                    Deleted = DateTimeOffset.UtcNow,
                    DeletedById = actorId,
                    IsDeleted = true
                });

            _ac.SaveChanges();
            return new ZabotaResult();
        }

    }
}

