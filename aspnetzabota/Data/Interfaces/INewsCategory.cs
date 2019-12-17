using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;
namespace aspnetzabota.Data.Interfaces
{
    public interface INewsCategory
    {
        IEnumerable<Category> Take { get; }
    }
}
