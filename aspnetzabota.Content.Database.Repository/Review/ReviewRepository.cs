using System;
using System.Linq;
using System.Threading.Tasks;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Datamodel.Review;

namespace aspnetzabota.Content.Database.Repository.Review
{
    internal class ReviewRepository : IReviewRepository
    {
        private static readonly Random random = new Random();
        private readonly ContentContext _appDBContext;

        public ReviewRepository(ContentContext appDBContext)
        {
            this._appDBContext = appDBContext;
        }
        public Task<Entities.Review[]> Random(int Count, bool trackChanges = false)
        {
            return _appDBContext.Reviews
                .HasTracking(trackChanges)
                .OrderBy(x => random.Next())
                .Take(Count)
                .ToArrayAsync();
        }
        public Task<Entities.Review[]> GetList(bool trackChanges = false)
        {
            return _appDBContext.Reviews
                .HasTracking(trackChanges)
                .OrderByDescending(x => x.Date)
                .ToArrayAsync();
        }
        public async Task Add(ZabotaReview review)
        {
            _appDBContext.Add(new Entities.Review
            {
                Id = review.Id,
                Author = review.Author,
                Date = review.Date,
                Email = review.Email,
                Text = review.Text
            });
            await _appDBContext.SaveChangesAsync();
        }
    }
}
