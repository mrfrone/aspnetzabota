using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using aspnetzabota.Content.Datamodel.Price;
using AutoMapper;
using aspnetzabota.Content.Database.Repository.PriceArticles;
using System.Threading.Tasks;

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
        private IEnumerable<ZabotaPrice> JsonPrice
        {
            get
            {
                using (StreamReader sr = new StreamReader("wwwroot/json/price.json"))
                {
                    return JsonConvert
                        .DeserializeObject<IEnumerable<ZabotaPrice>>(sr.ReadToEnd())
                        .OrderBy(c => c.DepartName)
                        .Where(c => !String.IsNullOrEmpty(c.DepartName));
                }
            }
        }
        private async Task<IEnumerable<ZabotaPrice>> PriceAtArticles()
        {
                var articles = await _priceArticles.Get();
                var mappedarticles =  _mapper.Map<IEnumerable<ZabotaPriceArticles>>(articles);
                var price = JsonPrice;
                foreach (var article in mappedarticles)
                {
                    price.FirstOrDefault(c => c.Id == article.PriceId).Article = article.Article;
                }
                return price;
        }
        public IEnumerable<ZabotaPrice> Get
        {
            get
            {
                return PriceAtArticles().Result;
            }
        }

        public IEnumerable<ZabotaPriceGroupsAndDepartments> GroupsAndDepartments
        {
            get
            {
                return JsonPrice
                    .GroupBy(u => new { u.GroupCode, u.GroupName })
                    .Select(c => new ZabotaPriceGroupsAndDepartments
                        {
                            GroupCode = c.Key.GroupCode,
                            GroupName = c.Key.GroupName,
                            DepartName = c.Select(u => u.DepartName).Distinct()
                        });
            }
        }

        public IEnumerable<ZabotaPriceGroupsAndDepartments> PriceDepartments(int id) 
        { 
            return GroupsAndDepartments.Where(c => c.GroupCode == id); 
        }
        public IEnumerable<ZabotaPrice> FromGroup(int id) 
        { 
            return PriceAtArticles().Result.Where(c => c.GroupCode == id); 
        }
        public IEnumerable<ZabotaPrice> FromDepartment(string id) 
        { 
            return PriceAtArticles().Result.Where(c => c.DepartName == id); 
        }
        public IEnumerable<ZabotaPrice> FromSearch(string line)
        {
            return PriceAtArticles().Result.Where(c => c.Name.IndexOf(line, StringComparison.InvariantCultureIgnoreCase) >= 0);
        }
    }
}
