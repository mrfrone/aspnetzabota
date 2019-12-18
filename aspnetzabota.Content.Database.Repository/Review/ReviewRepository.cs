using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using aspnetzabota.Content.Database.Context;

namespace aspnetzabota.Content.Database.Repository.Review
{
    public class ReviewRepository : IReview
    {
        private static readonly Random random = new Random();
        private readonly ContentContext appDBContext;

        public ReviewRepository(ContentContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Entities.Review> Take => appDBContext.Reviews;
        public IEnumerable<Entities.Review> Last(int Count) => appDBContext.Reviews.OrderByDescending(x => x.date).Take(Count);
        public IEnumerable<Entities.Review> GetPagedList(int pageNumber, int pageSize) => appDBContext.Reviews.OrderByDescending(x => x.date).ToPagedList(pageNumber, pageSize);
        public async Task Add(Entities.Review review)
        {
            review.date = DateTime.Now.ToShortDateString();
            await appDBContext.AddAsync(review);
            await appDBContext.SaveChangesAsync();
        }
    }
}
