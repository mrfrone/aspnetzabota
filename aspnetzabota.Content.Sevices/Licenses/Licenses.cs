using aspnetzabota.Content.Database.Context;
using aspnetzabota.Content.Database.Repository.Licenses;
using aspnetzabota.Content.Datamodel.License;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    }
}

