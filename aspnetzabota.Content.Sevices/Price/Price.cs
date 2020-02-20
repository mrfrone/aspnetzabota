using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using aspnetzabota.Content.Datamodel.Price;

namespace aspnetzabota.Content.Services.Price
{
    internal class Price : IPrice
    {
        private IEnumerable<ZabotaPrice> JsonPrice
        {
            get
            {
                using (StreamReader sr = new StreamReader("wwwroot/json/price.json"))
                {
                    return JsonConvert
                        .DeserializeObject<IEnumerable<ZabotaPrice>>(sr.ReadToEnd())
                        .OrderBy(c => c.depart_name)
                        .Where(c => !String.IsNullOrEmpty(c.depart_name));
                }
            }
        }
        public IEnumerable<ZabotaPrice> Get
        {
            get
            {
                return JsonPrice;
            }
        }

        public IEnumerable<ZabotaPriceGroupsAndDepartments> GroupsAndDepartments
        {
            get
            {
                return JsonPrice
                    .GroupBy(u => new { u.grcode, u.grname })
                    .Select(c => new ZabotaPriceGroupsAndDepartments
                        {
                            grcode = c.Key.grcode,
                            GroupName = c.Key.grname,
                            DepartName = c.Select(u => u.depart_name).Distinct()
                        });
            }
        }

        public IEnumerable<ZabotaPriceGroupsAndDepartments> PriceDepartments(int id) 
        { 
            return GroupsAndDepartments.Where(c => c.grcode == id); 
        }
        public IEnumerable<ZabotaPrice> FromGroup(int id) 
        { 
            return JsonPrice.Where(c => c.grcode == id); 
        }
        public IEnumerable<ZabotaPrice> FromDepartment(string id) 
        { 
            return JsonPrice.Where(c => c.depart_name == id); 
        }
        public IEnumerable<ZabotaPrice> FromSearch(string line)
        {
            return JsonPrice.Where(c => c.name.IndexOf(line, StringComparison.InvariantCultureIgnoreCase) >= 0);
        }
    }
}
