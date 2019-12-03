using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetzabota.Data.Repository
{
    public class ReviewRepository : IReview
    {
        private readonly AppDBContent appDBContent;

        public ReviewRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Review> Take => appDBContent.Reviews;
        public async Task Add(Review review)
        {
            review.date = DateTime.Now.ToShortDateString();
            await appDBContent.AddAsync(review);
            await appDBContent.SaveChangesAsync();
        }
    }
}
