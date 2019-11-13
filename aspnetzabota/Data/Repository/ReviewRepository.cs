using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace aspnetzabota.Data.Repository
{
    public class ReviewRepository : IReview
    {
        private readonly AppDBContext appDBContent;

        public ReviewRepository(AppDBContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Review> Take => appDBContent.Reviews;
    }
}
