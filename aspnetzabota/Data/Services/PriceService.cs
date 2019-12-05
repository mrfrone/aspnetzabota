using aspnetzabota.Data.Interfaces;
using aspnetzabota.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace aspnetzabota.Data.Services
{
    public class PriceService : IPriceService
    {
        private IEnumerable<Price> JsonPrice
        {
            get
            {
                using (StreamReader sr = new StreamReader("wwwroot/json/price.json"))
                {
                    return JsonConvert.DeserializeObject<IEnumerable<Price>>(sr.ReadToEnd())
                        .OrderBy(c => c.depart_name)
                        .Where(c => !String.IsNullOrEmpty(c.depart_name));
                }
            }
        }
        public IEnumerable<Price> Take => JsonPrice;
        public IEnumerable<PriceGroupsAndDepartmentsModel> GroupsAndDepartments =>
        JsonPrice.GroupBy(u => new { u.grcode, u.grname })
        .Select(c =>
        new PriceGroupsAndDepartmentsModel
        {
            grcode = c.Key.grcode,
            GroupName = c.Key.grname,
            DepartName = c.Select(u => u.depart_name).Distinct()
        });
        public  IEnumerable<PriceGroupsAndDepartmentsModel> PriceDepartments(int id) => GroupsAndDepartments.Where(c => c.grcode == id);
        public  IEnumerable<Price> FromGroup(int id) => JsonPrice.Where(c => c.grcode == id);
        public  IEnumerable<Price> FromDepartment(string id) => JsonPrice.Where(c => c.depart_name == id);
        public  IEnumerable<Price> FromSearch(string id) => JsonPrice.Where(c => c.name.Contains(id, StringComparison.InvariantCultureIgnoreCase));

    }
}
