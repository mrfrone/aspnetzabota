using System.Collections.Generic;
using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Content.Database.Repository.Category
{
    public interface ICategory
    {
        IEnumerable<Entities.Category> Take { get; }
    }
}
