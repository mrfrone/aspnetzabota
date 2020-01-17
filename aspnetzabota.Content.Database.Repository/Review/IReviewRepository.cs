using aspnetzabota.Content.Datamodel.Review;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Review
{
    public interface IReviewRepository
    {
        Task<Entities.Review[]> Random(int Count, bool trackChanges = false);
        Task<Entities.Review[]> GetList(bool trackChanges = false);
        Task Add(ZabotaReview review);
    }
}
