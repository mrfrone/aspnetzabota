using aspnetzabota.Data;
using System.Collections.Generic;

namespace aspnetzabota.Data.Interfaces
{
    public interface IDepartment
    {
        IEnumerable<Department> Take { get; }
    }
}
