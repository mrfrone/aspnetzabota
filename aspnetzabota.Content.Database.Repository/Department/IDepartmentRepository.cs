using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Department
{
    public interface IDepartmentRepository
    {
        Task<Entities.Department[]> Get(bool trackChanges = false);
    }
}
