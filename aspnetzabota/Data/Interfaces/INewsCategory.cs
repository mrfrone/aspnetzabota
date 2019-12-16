using System.Collections.Generic;
using aspnetzabota.Data;
namespace aspnetzabota.Data.Interfaces
{
    public interface INewsCategory
    {
        IEnumerable<Category> Take { get; }
    }
}
