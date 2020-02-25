using System.Collections.Generic;
using aspnetzabota.Content.Datamodel.Price;

namespace aspnetzabota.Web.ViewModels
{
    public class PriceHelpViewModel
    {
        public IEnumerable<ZabotaPrice> Price { get; set; }
    }
}
