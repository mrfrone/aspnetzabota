using aspnetzabota.Content.Datamodel.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Department
{
    public interface IDepartmentRepository
    {
        Task<Entities.Department[]> Get(bool trackChanges = false);
        Task Add(ZabotaDepartment model);
        Task Delete(int id);
    }
}
