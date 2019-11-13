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

    }
}
