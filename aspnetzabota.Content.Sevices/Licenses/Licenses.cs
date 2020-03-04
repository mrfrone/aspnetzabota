using aspnetzabota.Common.Result;
using aspnetzabota.Content.Database.Repository.Licenses;
using aspnetzabota.Content.Datamodel.License;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Licenses
{
    internal class Licenses : ILicenses
    {
        private readonly IMapper _mapper;
        private readonly ILicensesRepository _licensesRepository;
        public Licenses(IMapper mapper, ILicensesRepository licensesRepository)
        {
            _mapper = mapper;
            _licensesRepository = licensesRepository;
        }

        public async Task<IEnumerable<ZabotaLicenses>> GetLicenses()
        {
            var result = await _licensesRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaLicenses>>(result);
        }
        public async Task<ZabotaResult> AddLicense(ZabotaLicenses license)
        {
            await _licensesRepository.Add(new Database.Entities.Licenses
            {
                Id = license.Id,
                Name = license.Name
            });
            return new ZabotaResult();
        }
        public async Task<ZabotaResult> AddPhoto(ZabotaLicensesPhoto photo)
        {
             await _licensesRepository.AddPhoto(new Database.Entities.LicensesPhoto
            {
                Path = "~/images/Licenses/" + photo.Path,
                LicensesId = photo.LicensesId
            });
            return new ZabotaResult();
        }
        public async Task<ZabotaResult> DeleteLicense(int id)
        {
            await _licensesRepository.Delete(id);
            return new ZabotaResult();
        }
        public async Task<ZabotaResult> DeletePhoto(int id)
        {
            await _licensesRepository.DeletePhoto(id);
            return new ZabotaResult();
        }
    }
}

