using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace aspnetzabota.Content.Services.Price
{
    public class Price : IPrice
    {
        private IEnumerable<Database.Entities.Price> JsonPrice
        {
            get
            {
                using (StreamReader sr = new StreamReader("wwwroot/json/price.json"))
                {
                    return JsonConvert.DeserializeObject<IEnumerable<Database.Entities.Price>>(sr.ReadToEnd())
                        .OrderBy(c => c.depart_name)
                        .Where(c => !String.IsNullOrEmpty(c.depart_name));
                }
            }
        }
        public IEnumerable<Database.Entities.Price> Take => JsonPrice;
        public IEnumerable<Database.Entities.PriceGroupsAndDepartmentsModel> GroupsAndDepartments =>
        JsonPrice.GroupBy(u => new { u.grcode, u.grname })
        .Select(c =>
        new Database.Entities.PriceGroupsAndDepartmentsModel
        {
            grcode = c.Key.grcode,
            GroupName = c.Key.grname,
            DepartName = c.Select(u => u.depart_name).Distinct()
        });
        public  IEnumerable<Database.Entities.PriceGroupsAndDepartmentsModel> PriceDepartments(int id) => GroupsAndDepartments.Where(c => c.grcode == id);
        public  IEnumerable<Database.Entities.Price> FromGroup(int id) => JsonPrice.Where(c => c.grcode == id);
        public  IEnumerable<Database.Entities.Price> FromDepartment(string id) => JsonPrice.Where(c => c.depart_name == id);
        public IEnumerable<Database.Entities.Price> FromSearch(string line) => JsonPrice.Where(c => c.name.Contains(line, StringComparison.InvariantCultureIgnoreCase));

    }
}
