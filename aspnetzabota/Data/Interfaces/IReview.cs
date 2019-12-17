using aspnetzabota.Content.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Data.Interfaces
{
    public interface IReview
    {
        IEnumerable<Review> Take { get; }
        IEnumerable<Review> Random(int Count);
        IEnumerable<Review> GetPagedList(int pageNumber, int pageSize);
        Task Add(Review review);
    }
}
