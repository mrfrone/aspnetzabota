using System.Collections.Generic;
using X.PagedList;
using System.Threading.Tasks;
using AutoMapper;
using aspnetzabota.Content.Datamodel.News;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Database.Repository.News;
using aspnetzabota.Common.Result;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace aspnetzabota.Content.Services.News
{
    internal class News : INews
    {
        private readonly IMapper _mapper;
        private readonly INewsRepository _newsRepository;
        public News(IMapper mapper, INewsRepository newsRepository)
        {
            _mapper = mapper;
            _newsRepository = newsRepository;
        }
        public async Task<IEnumerable<ZabotaNews>> GetLastNews(int Count)
        {
            var result = await _newsRepository.GetLast(Count);
            return _mapper.Map<IEnumerable<ZabotaNews>>(result);
        }
        public async Task<ZabotaNews> GetSingleNews(int id) 
        {
            var result = await _newsRepository.GetSingle(id);
            return _mapper.Map<ZabotaNews>(result);
        }
        public async Task<IEnumerable<ZabotaNews>> GetFromNewsCategory(int id, int pageNumber, int pageSize)
        {
            var result = await _newsRepository.GetFromCategory(id);
            return _mapper.Map<IEnumerable<ZabotaNews>>(result).ToPagedList(pageNumber, pageSize);
        }
        public async Task<IEnumerable<ZabotaNews>> GetPagedNewsList(int pageNumber, int pageSize)
        {
            var result = await _newsRepository.GetList();
            return _mapper.Map<IEnumerable<ZabotaNews>>(result).ToPagedList(pageNumber, pageSize);
        }
        public async Task<ZabotaResult> AddNews(ZabotaNews news)
        {
            await _newsRepository.Add(new Database.Entities.News
            {
                Name = news.Name,
                Description = news.Description,
                IMG = "~/images/Articles/" + news.IMG,
                Date = DateTimeOffset.UtcNow,
                categoryID = news.CategoryID
            });

            return new ZabotaResult();
        }
        public async Task<ZabotaResult> DeleteByID(int id)
        {
            await _newsRepository.Delete(id);
            return new ZabotaResult();
        }
    }
}
