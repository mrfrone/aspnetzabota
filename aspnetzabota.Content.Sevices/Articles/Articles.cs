using System.Collections.Generic;
using X.PagedList;
using System.Threading.Tasks;
using AutoMapper;
using aspnetzabota.Content.Datamodel.Articles;
using aspnetzabota.Content.Database.Repository.Articles;
using aspnetzabota.Common.Result;
using System;
using System.Linq;

namespace aspnetzabota.Content.Services.Articles
{
    internal class Articles : IArticles
    {
        private readonly IMapper _mapper;
        private readonly IArticlesRepository _newsRepository;
        public Articles(IMapper mapper, IArticlesRepository newsRepository)
        {
            _mapper = mapper;
            _newsRepository = newsRepository;
        }
        public async Task<IEnumerable<ZabotaArticles>> GetLastNews(int Count)
        {
            var result = await _newsRepository.GetLast(Count);
            return _mapper.Map<IEnumerable<ZabotaArticles>>(result);
        }
        public async Task<ZabotaArticles> GetSingleArticle(int id) 
        {
            var result = await _newsRepository.GetSingle(id);
            return _mapper.Map<ZabotaArticles>(result);
        }
        public async Task<IEnumerable<ZabotaArticles>> GetFromArticleCategory(int id, int pageNumber, int pageSize)
        {
            var result = await _newsRepository.GetFromCategory(id);
            return _mapper.Map<IEnumerable<ZabotaArticles>>(result).ToPagedList(pageNumber, pageSize);
        }
        public async Task<IEnumerable<ZabotaArticles>> GetPagedArticlesList(int pageNumber, int pageSize)
        {
            var result = await _newsRepository.GetList();
            return _mapper.Map<IEnumerable<ZabotaArticles>>(result).ToPagedList(pageNumber, pageSize);
        }
        public async Task<IEnumerable<ZabotaArticles>> GetAllArticlesList()
        {
            var result = await _newsRepository.GetList();
            return _mapper.Map<IEnumerable<ZabotaArticles>>(result).Where(a => a.CategoryID == 3);
        }
        public async Task<ZabotaResult> AddArticle(ZabotaArticles model)
        {
            await _newsRepository.Add(model);

            return new ZabotaResult();
        }
        public async Task<ZabotaResult> DeleteArticleByID(int id)
        {
            await _newsRepository.Delete(id);

            return new ZabotaResult();
        }
    }
}
