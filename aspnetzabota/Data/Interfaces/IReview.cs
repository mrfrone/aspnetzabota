using aspnetzabota.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Data.Interfaces
{
    public interface IReview
    {
        IEnumerable<Review> Take { get; }
        IEnumerable<Review> GetPagedList(int pageNumber, int pageSize);
        Task Add(Review review);
    }
}
