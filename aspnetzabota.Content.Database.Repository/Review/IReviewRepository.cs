using aspnetzabota.Content.Datamodel.Review;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.Review
{
    public interface IReviewRepository
    {
        Task<Entities.Review[]> Random(int Count, bool trackChanges = false);
        Task<Entities.Review[]> GetList(bool trackChanges = false, bool Moderated = false);
        Task Add(ZabotaReview review);
        Task Delete(int id);
        Task Moderate(int id);
    }
}
