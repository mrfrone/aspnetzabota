using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using aspnetzabota.Content.Datamodel.Price;
using AutoMapper;
using aspnetzabota.Content.Database.Entities;
using aspnetzabota.Content.Database.Repository.PriceArticles;
using System.Threading.Tasks;
using aspnetzabota.Common.Result;

namespace aspnetzabota.Content.Services.Price
{
    internal class PriceArticles : IPriceArticles
    {
        private readonly IPriceArticlesRepository _priceArticles;
        private readonly IMapper _mapper;
        public PriceArticles(IPriceArticlesRepository priceArticles, IMapper mapper)
        {
            _priceArticles = priceArticles;
            _mapper = mapper;
        }
        public async Task<ZabotaResult> AddPriceArticle(ZabotaPriceArticles article)
        {
            await _priceArticles.Add(new Database.Entities.PriceArticles
            {
                Id = article.Id,
                PriceId = article.PriceId,
                ArticleId = article.ArticleId
            });
            return new ZabotaResult();
        }
        public async Task<IEnumerable<ZabotaPriceArticles>> GetPriceArticles()
        {
            var result = await _priceArticles.Get();
            return _mapper.Map<IEnumerable<ZabotaPriceArticles>>(result);
        }
    }
}
