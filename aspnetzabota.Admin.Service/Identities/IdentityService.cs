using System.Threading.Tasks;
using AutoMapper;
using aspnetzabota.Admin.Database.Repository.Identities;
using aspnetzabota.Admin.Datamodel.Identities;
using System.Collections.Generic;
using aspnetzabota.Admin.Forms.Login;

namespace aspnetzabota.Admin.Services.Identities
{
    internal class IdentityService : IIdentityService
    {
        private readonly IIdentitiesRepository _identitiesRepository;
        private readonly IMapper _mapper;

        public IdentityService(IIdentitiesRepository identitiesRepository, IMapper mapper)
        {
            _identitiesRepository = identitiesRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ZabotaIdentity>> GetIdentities()
        {
            var result = await _identitiesRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaIdentity>>(result);
        }
        public async Task<ZabotaIdentity> GetIdentityByTokenId(int id)
        {
            var model = await _identitiesRepository.IdentityByTokenId(id);
            if (model == null)
                return null;

            var mappedModel = _mapper.Map<Database.Entities.Identities, ZabotaIdentity>(model);
            return mappedModel;
        }
        public async Task<bool> AddIdentity(LoginForm form) 
        {
            var model = await _identitiesRepository.IdentityByLogin(form.Login);
            if (model != null)
                return false;

            await _identitiesRepository.Add(form);
            return true;
        }
        public async Task<bool> DeleteIdentity(int id, int actorId) 
        {
            var result = await _identitiesRepository.Delete(id, actorId);

            return result;
        }
    }
}