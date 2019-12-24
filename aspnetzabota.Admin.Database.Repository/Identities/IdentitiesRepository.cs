using aspnetzabota.Admin.Database.Context;
using aspnetzabota.Admin.Database.Repository.Tokens;
using aspnetzabota.Admin.Forms.Login;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace aspnetzabota.Admin.Database.Repository.Identities
{
    class IdentitiesRepository : IIdentitiesRepository
    {
        private readonly AdminContext _ac;
        private readonly ITokensRepository _tokensRepository;

        public IdentitiesRepository(AdminContext ac, ITokensRepository tokensRepository)
        {
            _ac = ac;
            _tokensRepository = tokensRepository;
        }

        public async Task<Entities.Identities> IdentityByTokenId(int id)
        {
            var jwt = await _tokensRepository.GetById(id);
            if (jwt == null || jwt.IsDeleted)
                return null;

            return await _ac.Identities.FirstOrDefaultAsync(u => u.Id == jwt.IdentityId);
        }

        public async Task<Entities.Identities> GetByLoginAndPassword(LoginForm form)
        {
            var login = form.Login.Trim();

            var user = await _ac.Identities.FirstOrDefaultAsync(u => u.Login == login);

            return user;
        }

        public Task<bool> IdentityExistsAsync(int identityId)
        {
            return _ac.Identities.AnyAsync(u => u.Id == identityId);
        }
    }
}

