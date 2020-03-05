using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using aspnetzabota.Content.Datamodel.Price;
using AutoMapper;
using System.Threading.Tasks;
using aspnetzabota.Common.Result;
using aspnetzabota.Content.Database.Repository.PriceArticles;
using aspnetzabota.Common.Result.ErrorCodes;

namespace aspnetzabota.Content.Services.Price
{
    internal class Price : IPrice
    {
        private readonly IPriceArticlesRepository _priceArticles;
        private readonly IMapper _mapper;
        public Price(IPriceArticlesRepository priceArticles, IMapper mapper)
        {
            _priceArticles = priceArticles;
            _mapper = mapper;
        }
        private async Task<IEnumerable<ZabotaPrice>> JsonPrice()
        {
                using (StreamReader sr = new StreamReader("wwwroot/json/price.json"))
                {
                    return JsonConvert
                        .DeserializeObject<IEnumerable<ZabotaPrice>>(await sr.ReadToEndAsync())
                        .OrderBy(c => c.DepartName)
                        .Where(c => !String.IsNullOrEmpty(c.DepartName));
                }
        }
        private async Task<IEnumerable<ZabotaPrice>> PriceAtArticles()
        {
                var articles = await GetPriceArticles(); 
                var price = await JsonPrice();
                foreach (var article in articles)
                {
                   if (!String.IsNullOrEmpty(price.FirstOrDefault(c => c.Id == article.PriceId).Name))
                    price.FirstOrDefault(c => c.Id == article.PriceId).Article = article.Article;
                }
                return price;
        }
        public async Task<IEnumerable<ZabotaPrice>> Get()
        {
                return await PriceAtArticles();
        }

        public async Task<IEnumerable<ZabotaPriceGroupsAndDepartments>> GroupsAndDepartments()
        {
            var price = await JsonPrice();
                return price
                .GroupBy(u => new { u.GroupCode, u.GroupName })
                .Select(c => new ZabotaPriceGroupsAndDepartments
                    {
                        GroupCode = c.Key.GroupCode,
                        GroupName = c.Key.GroupName,
                        DepartName = c.Select(u => u.DepartName).Distinct()
                    });
        }

        public async Task<IEnumerable<ZabotaPriceGroupsAndDepartments>> PriceDepartments(int id) 
        {
            var groups = await GroupsAndDepartments();
            return groups.Where(c => c.GroupCode == id); 
        }
        public async Task<IEnumerable<ZabotaPrice>> FromGroup(int id) 
        {
            var price = await JsonPrice();
            return price.Where(c => c.GroupCode == id); 
        }
        public async Task<IEnumerable<ZabotaPrice>> FromDepartment(string id) 
        {
            var price = await JsonPrice();
            return price.Where(c => c.DepartName == id); 
        }
        public async Task<IEnumerable<ZabotaPrice>> FromSearch(string line)
        {
            var price = await JsonPrice();
            return price.Where(c => c.Name.IndexOf(line, StringComparison.InvariantCultureIgnoreCase) >= 0);
        }
        public async Task<ZabotaResult> AddPriceArticle(ZabotaPriceArticles article)
        {
            var price = await JsonPrice();
            if (!String.IsNullOrEmpty(price.FirstOrDefault(c => c.Id == article.PriceId).Name))
            {
                await _priceArticles.Add(new Database.Entities.PriceArticles
                {
                    Id = article.Id,
                    PriceId = article.PriceId,
                    ArticleId = article.ArticleId
                });
                return new ZabotaResult();
            }
            else
            {
                return ZabotaErrorCodes.IdNotFound;
            }
        }
        public async Task<IEnumerable<ZabotaPriceArticles>> GetPriceArticles()
        {
            var result = await _priceArticles.Get();
            return _mapper.Map<IEnumerable<ZabotaPriceArticles>>(result);
        }
        public async Task DeletePriceArticle(int id)
        {
            await _priceArticles.Delete(id);
        }
    }
}
