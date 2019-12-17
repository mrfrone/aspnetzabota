using System.Collections.Generic;

namespace aspnetzabota.Content.Database.Repository.Department
{
    public interface IDepartment
    {
        IEnumerable<Entities.Department> Take { get; }
    }
}
