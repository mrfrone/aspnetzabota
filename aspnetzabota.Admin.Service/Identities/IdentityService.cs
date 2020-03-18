using System.Threading.Tasks;
using AutoMapper;
using aspnetzabota.Admin.Database.Repository.Identities;
using aspnetzabota.Admin.Datamodel.Identities;
using aspnetzabota.Common.Result;
using aspnetzabota.Common.Result.ErrorCodes;
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
        public async Task<ZabotaResult<ZabotaIdentity>> GetIdentityByTokenId(int id)
        {
            var model = await _identitiesRepository.IdentityByTokenId(id);
            if (model == null)
                return ZabotaErrorCodes.CannotFindIdentityByTokenId;

            var mappedModel = _mapper.Map<Database.Entities.Identities, ZabotaIdentity>(model);
            return new ZabotaResult<ZabotaIdentity>(mappedModel);
        }
        public async Task<ZabotaResult> AddIdentity(LoginForm form) 
        {
            var model = await _identitiesRepository.IdentityByLogin(form.Login);
            if (model != null)
                return ZabotaErrorCodes.UserExists;

            await _identitiesRepository.Add(form);
            return new ZabotaResult();
        }
        public async Task<ZabotaResult> DeleteIdentity(int id, int actorId) 
        {
            var result = await _identitiesRepository.Delete(id, actorId);

            return result;
        }
    }
}