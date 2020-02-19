﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using System.Threading.Tasks;

namespace aspnetzabota.Content.Database.Repository.News
{
    internal class NewsRepository : INewsRepository
    {
        private readonly ContentContext _appDBContext;

        public NewsRepository(ContentContext appDBContext)
        {
            this._appDBContext = appDBContext;
        }
        public Task<Entities.Articles[]> GetLast(int Count, bool trackChanges = false)
        {
            return _appDBContext.News
                .HasTracking(trackChanges)
                .OrderByDescending(x => x.Date)
                .Take(Count).ToArrayAsync();
        }
        public Task<Entities.Articles> GetSingle(int id, bool trackChanges = false) 
        { 
            return _appDBContext.News
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(p => p.Id == id); 
        }
        public Task<Entities.Articles[]> GetFromCategory(int id, bool trackChanges = false)
        {
            return _appDBContext.News
                .HasTracking(trackChanges)
                .Where(c => c.CategoryID == id)
                .OrderByDescending(x => x.Date)
                .ToArrayAsync();
        }
        public Task<Entities.Articles[]> GetList(bool trackChanges = false)
        {
            return _appDBContext.News
            .HasTracking(trackChanges)
            .Include(p => p.Category)
            .OrderByDescending(x => x.Date)
            .ToArrayAsync();
        }
        public async Task Add(Entities.Articles news)
        {
            _appDBContext.News.Add(news);
            await _appDBContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var article = new Entities.Articles { Id = id };
            _appDBContext.News.Attach(article);
            _appDBContext.News.Remove(article);
            await _appDBContext.SaveChangesAsync();
        }

    }
}
