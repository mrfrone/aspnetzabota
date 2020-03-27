using aspnetzabota.Common.Upload;
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
        private readonly IUpload _upload;
        public Licenses(IMapper mapper, ILicensesRepository licensesRepository, IUpload upload)
        {
            _mapper = mapper;
            _licensesRepository = licensesRepository;
            _upload = upload;
        }

        public async Task<IEnumerable<ZabotaLicenses>> GetLicenses()
        {
            var result = await _licensesRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaLicenses>>(result);
        }
        public async Task<bool> AddLicense(ZabotaLicenses model)
        {
            await _licensesRepository.Add(model);
            return true;
        }
        public async Task<bool> AddPhoto(ZabotaLicensesPhoto model)
        {
            await _licensesRepository.AddPhoto(model);
            return true;
        }
        public async Task<bool> DeleteLicense(int id)
        {
            var result = await _licensesRepository.GetSingleLicense(id);
            var mapped = _mapper.Map<ZabotaLicenses>(result);
            foreach(var path in mapped.Photo)
            {
                _upload.DeleteImage(path.Path);
            }
            
            await _licensesRepository.Delete(id);
            return true;
        }
        public async Task<bool> DeletePhoto(int id)
        {
            var result = await _licensesRepository.GetSinglePhoto(id);
            _upload.DeleteImage(result.Path);

            await _licensesRepository.DeletePhoto(id);
            return true;
        }
    }
}

