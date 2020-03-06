using aspnetzabota.Common.Result;
using aspnetzabota.Content.Datamodel.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Department
{
    public interface IDepartment
    {
        Task<IEnumerable<ZabotaDepartment>> GetDepartments();
        Task<ZabotaResult> AddDepartment(ZabotaDepartment model);
        Task<ZabotaResult> DeleteDepartment(int id);
    }
}
