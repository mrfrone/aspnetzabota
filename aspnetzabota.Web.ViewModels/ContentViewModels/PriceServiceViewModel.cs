using aspnetzabota.Content.Datamodel.Price;
using System.Collections.Generic;

namespace aspnetzabota.Web.ViewModels
{
    public class PriceServiceViewModel
    {
        public IEnumerable<ZabotaPrice> PriceService { get; set; }
        public IEnumerable<ZabotaPriceGroupsAndDepartments> PriceServiceDep { get; set; }
    }
}
