using aspnetzabota.Content.Datamodel.Articles;
using System.Collections.Generic;

namespace aspnetzabota.Content.Datamodel.Department
{
    public class ZabotaDepartment
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string ShortName { get; set; }
        public string IMG { get; set; }
        public string Description { get; set; }
        public int DepartmentPriceID { get; set; }
        public IEnumerable<ZabotaArticles> Articles { get; set; }
    }
}
