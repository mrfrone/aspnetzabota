using aspnetzabota.Content.Datamodel.Review;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Services.Review
{
    public interface IReview
    {
        Task<IEnumerable<ZabotaReview>> RandomReviews(int Count);
        Task<IEnumerable<ZabotaReview>> GetPagedReviewsList(int pageNumber, int pageSize, bool Moderated = false);
        Task<bool> Add(ZabotaReview review);
        Task<bool> ModerateReview(int id);
        Task<bool> DeleteReview(int id);

        }
}
