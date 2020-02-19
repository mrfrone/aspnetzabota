using System.Collections.Generic;

namespace aspnetzabota.Content.Datamodel.Articles
{
    public class ZabotaCategory
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<ZabotaArticles> News { get; set; }
    }
}
