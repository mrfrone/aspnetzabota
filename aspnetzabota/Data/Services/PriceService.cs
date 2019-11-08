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
        public IEnumerable<Price> All => JsonPrice;
        public IEnumerable<PriceGroupsAndDepartmentsModel> PriceGroupsAndDepartments =>
                JsonPrice.GroupBy(u => new { u.grcode, u.grname })
                .Select(c =>
                new PriceGroupsAndDepartmentsModel
                {
                    grcode = c.Key.grcode,
                    GroupName = c.Key.grname,
                    DepartName = c.Select(u => u.depart_name).Distinct()
                });

    }
}
