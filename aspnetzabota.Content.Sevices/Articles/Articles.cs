using System.Collections.Generic;
using X.PagedList;
using System.Threading.Tasks;
using AutoMapper;
using aspnetzabota.Content.Datamodel.Articles;
using aspnetzabota.Content.Database.Repository.Articles;
using aspnetzabota.Common.Result;
using System;
using System.Linq;
using aspnetzabota.Common.Upload;

namespace aspnetzabota.Content.Services.Articles
{
    internal class Articles : IArticles
    {
        private readonly IMapper _mapper;
        private readonly IArticlesRepository _articlesRepository;
        private readonly IUpload _upload;
        public Articles(IMapper mapper, IArticlesRepository articlesRepository, IUpload upload)
        {
            _mapper = mapper;
            _articlesRepository = articlesRepository;
            _upload = upload;
        }
        public async Task<IEnumerable<ZabotaArticles>> GetLastNews(int Count)
        {
            var result = await _articlesRepository.GetLast(Count);
            return _mapper.Map<IEnumerable<ZabotaArticles>>(result);
        }
        public async Task<ZabotaArticles> GetSingleArticle(int id) 
        {
            var result = await _articlesRepository.GetSingle(id);
            return _mapper.Map<ZabotaArticles>(result);
        }
        public async Task<IEnumerable<ZabotaArticles>> GetFromArticleCategory(int id, int pageNumber, int pageSize)
        {
            var result = await _articlesRepository.GetFromCategory(id);
            return _mapper.Map<IEnumerable<ZabotaArticles>>(result).ToPagedList(pageNumber, pageSize);
        }
        public async Task<IEnumerable<ZabotaArticles>> GetPagedArticlesList(int pageNumber, int pageSize)
        {
            var result = await _articlesRepository.GetList();
            return _mapper.Map<IEnumerable<ZabotaArticles>>(result).ToPagedList(pageNumber, pageSize);
        }
        public async Task<IEnumerable<ZabotaArticles>> GetAllArticlesList()
        {
            var result = await _articlesRepository.GetList();
            return _mapper.Map<IEnumerable<ZabotaArticles>>(result).Where(a => a.CategoryID == 3);
        }
        public async Task<ZabotaResult> AddArticle(ZabotaArticles model)
        {
            await _articlesRepository.Add(model);

            return new ZabotaResult();
        }
        public async Task<ZabotaResult> UpdateArticle(ZabotaArticles model)
        {
            model.Date = DateTimeOffset.UtcNow;
            await _articlesRepository.Update(model);

            return new ZabotaResult();
        }
        public async Task<ZabotaResult> DeleteArticleByID(int id)
        {
            var result = await _articlesRepository.GetSingle(id);
            _upload.DeleteImage(result.Img);

            await _articlesRepository.Delete(id);

            return new ZabotaResult();
        }
    }
}
