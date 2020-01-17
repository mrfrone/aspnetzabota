using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;

namespace aspnetzabota.Content.Database.Repository.Review
{
    public class ReviewRepository : IReviewRepository
    {
        private static readonly Random random = new Random();
        private readonly ContentContext appDBContext;

        public ReviewRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Entities.Review> Random(int Count, bool trackChanges = false) =>
            appDBContext.Reviews.
                HasTracking(trackChanges).
                OrderBy(x => random.Next()).
                Take(Count);
        public IEnumerable<Entities.Review> GetPagedList(int pageNumber, int pageSize, bool trackChanges = false) =>
            appDBContext.Reviews.
                HasTracking(trackChanges).
                OrderByDescending(x => x.date).
                ToPagedList(pageNumber, pageSize);
        public async Task Add(Entities.Review review)
        {
            review.date = DateTime.Now.ToShortDateString();
            appDBContext.Add(review);
            await appDBContext.SaveChangesAsync();
        }
    }
}
