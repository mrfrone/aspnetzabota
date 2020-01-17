using aspnetzabota.Content.Datamodel.Review;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Review
{
    public interface IReview
    {
        Task<IEnumerable<ZabotaReview>> RandomReviews(int Count);
        Task<IEnumerable<ZabotaReview>> GetPagedReviewsList(int pageNumber, int pageSize);
        Task Add(ZabotaReview review);

    }
}
