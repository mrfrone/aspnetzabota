using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Review
{
    public interface IReview
    {
        IEnumerable<Entities.Review> Take { get; }
        IEnumerable<Entities.Review> Random(int Count);
        IEnumerable<Entities.Review> GetPagedList(int pageNumber, int pageSize);
        Task Add(Entities.Review review);
    }
}
