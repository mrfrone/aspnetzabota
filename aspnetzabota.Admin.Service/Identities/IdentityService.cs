using System.Threading.Tasks;
using AutoMapper;
using aspnetzabota.Admin.Database.Repository.Identities;
using aspnetzabota.Admin.Datamodel.Identities;
using aspnetzabota.Common.Result;
using aspnetzabota.Common.Result.ErrorCodes;

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


        public async Task<ZabotaResult<ZabotaIdentity>> GetIdentityByTokenId(int id)
        {
            var model = await _identitiesRepository.IdentityByTokenId(id);
            if (model == null)
                return ZabotaErrorCodes.CannotFindIdentityByTokenId;

            var mappedModel = _mapper.Map<Database.Entities.Identities, ZabotaIdentity>(model);
            return new ZabotaResult<ZabotaIdentity>(mappedModel);
        }
    }
}