using System.Linq;
using Microsoft.EntityFrameworkCore;
using aspnetzabota.Content.Database.Context;
using aspnetzabota.Common.EFCore.Extensions;
using System.Threading.Tasks;
using aspnetzabota.Content.Datamodel.Articles;
using System;
using Z.EntityFramework.Plus;

namespace aspnetzabota.Content.Database.Repository.Articles
{
    internal class ArticlesRepository : IArticlesRepository
    {
        private readonly ContentContext _appDBContext;

        public ArticlesRepository(ContentContext appDBContext)
        {
            this._appDBContext = appDBContext;
        }
        public async Task<Entities.Articles[]> GetLast(int Count, bool trackChanges = false)
        {
            return await _appDBContext.Articles
                .HasTracking(trackChanges)
                .Where(n => n.CategoryID != 3)
                .OrderByDescending(x => x.Date)
                .Take(Count).ToArrayAsync();
        }
        public async Task<Entities.Articles> GetSingle(int id, bool trackChanges = false) 
        { 
            return await _appDBContext.Articles
                .HasTracking(trackChanges)
                .FirstOrDefaultAsync(p => p.Id == id); 
        }
        public async Task<Entities.Articles[]> GetFromCategory(int id, bool trackChanges = false)
        {
            return await _appDBContext.Articles
                .HasTracking(trackChanges)
                .Where(c => c.CategoryID == id)
                .OrderByDescending(x => x.Date)
                .ToArrayAsync();
        }
        public async Task<Entities.Articles[]> GetList(bool trackChanges = false)
        {
            return await _appDBContext.Articles
            .HasTracking(trackChanges)
            .Include(p => p.Category)
            .OrderByDescending(x => x.Date)
            .ToArrayAsync();
        }
        public Task Add(ZabotaArticles model)
        {
            _appDBContext.Articles.Add(new Entities.Articles
            {
                Name = model.Name,
                Description = model.Description,
                Img = "~/images/Articles/" + model.IMG,
                Date = DateTimeOffset.UtcNow,
                CategoryID = model.CategoryID,
                DepartmentId = model.DepartmentId
            });
            return _appDBContext.SaveChangesAsync();
        }
        public Task Update(ZabotaArticles model)
        {
            _appDBContext.Articles
                .AsQueryable()
                .Where(x => x.Id == model.Id)
                .Update(r => new Entities.Articles 
                { 
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Img = model.IMG,
                    Date = model.Date,
                    CategoryID = model.CategoryID,
                    DepartmentId = model.DepartmentId
                });

            return _appDBContext.SaveChangesAsync();
        }
        public Task Delete(int id)
        {
            _appDBContext.Articles
                .AsQueryable()
                .Where(x => x.Id == id)
                .Delete();

            return _appDBContext.SaveChangesAsync();
        }

    }
}
