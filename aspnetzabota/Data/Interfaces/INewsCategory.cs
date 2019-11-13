using System.Collections.Generic;
using aspnetzabota.Data.Models;

namespace aspnetzabota.Data.Interfaces
{
    public interface INewsCategory
    {
        IEnumerable<Category> Take { get; }
    }
}
