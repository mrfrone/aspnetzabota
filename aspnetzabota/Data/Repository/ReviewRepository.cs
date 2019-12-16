using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace aspnetzabota.Data.Repository
{
    public class ReviewRepository : IReview
    {
        private static readonly Random random = new Random();
        private readonly AppDBContext appDBContext;

        public ReviewRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Review> Take => appDBContext.Reviews;
        public IEnumerable<Review> Random(int Count) => appDBContext.Reviews.OrderBy(x => random.Next()).Take(Count);
        public IEnumerable<Review> GetPagedList(int pageNumber, int pageSize) => appDBContext.Reviews.OrderByDescending(x => x.date).ToPagedList(pageNumber, pageSize);
        public async Task Add(Review review)
        {
            review.date = DateTime.Now.ToShortDateString();
            await appDBContext.AddAsync(review);
            await appDBContext.SaveChangesAsync();
        }
    }
}
