using System;
using System.Linq;
using System.Threading.Tasks;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Datamodel.Review;
using Z.EntityFramework.Plus;

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
        public async Task<Entities.Review[]> Random(int Count, bool trackChanges = false)
        {
            return await _appDBContext.Reviews
                .HasTracking(trackChanges)
                .OrderBy(x => random.Next())
                .Where(x => x.IsModerated)
                .Take(Count)
                .ToArrayAsync();
        }
        public async Task<Entities.Review[]> GetList(bool trackChanges = false, bool Moderated = false)
        {
            if (Moderated)
            {
                return await _appDBContext.Reviews
                    .HasTracking(trackChanges)
                    .OrderByDescending(x => x.Date)
                    .Where(x => x.IsModerated)
                    .ToArrayAsync();
            }
            else
            {
                return await _appDBContext.Reviews
                    .HasTracking(trackChanges)
                    .OrderByDescending(x => x.Date)
                    .ToArrayAsync();
            }
        }
        public Task Add(ZabotaReview review)
        {
            _appDBContext.Add(new Entities.Review
            {
                Id = review.Id,
                Author = review.Author,
                Date = review.Date,
                Email = review.Email,
                Text = review.Text,
                IsModerated = false
            });
            return _appDBContext.SaveChangesAsync();
        }
        public Task Delete(int id)
        {
            _appDBContext.Reviews
                .Where(r => r.Id == id)
                .Delete();
            return _appDBContext.SaveChangesAsync();
        }
        public Task Moderate(int id)
        {
            _appDBContext.Reviews
                .Where(r => r.Id == id)
                .Update(r => new Entities.Review { IsModerated = true });

            return _appDBContext.SaveChangesAsync();
        }
    }
}
