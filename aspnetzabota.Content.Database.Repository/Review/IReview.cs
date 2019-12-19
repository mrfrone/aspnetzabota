using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Review
{
    public interface IReview
    {
        IEnumerable<Entities.Review> Random(int Count, bool trackChanges = false);
        IEnumerable<Entities.Review> GetPagedList(int pageNumber, int pageSize, bool trackChanges = false);
        Task Add(Entities.Review review);
    }
}
