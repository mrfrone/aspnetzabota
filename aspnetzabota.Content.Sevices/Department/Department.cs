using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using aspnetzabota.Content.Database.Repository.Department;
using aspnetzabota.Content.Datamodel.Department;

namespace aspnetzabota.Content.Services.Department
{
    internal class Department : IDepartment
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        public Department(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<ZabotaDepartment>> GetDepartments()
        {
            var result = await _departmentRepository.Get();
            return _mapper.Map<IEnumerable<ZabotaDepartment>>(result);
        }
        public async Task<bool> AddDepartment(ZabotaDepartment model)
        {
            await _departmentRepository.Add(model);

            return true;
        }
        public async Task<bool> DeleteDepartment(int id)
        {
            await _departmentRepository.Delete(id);

            return true;
        }
    }
}
