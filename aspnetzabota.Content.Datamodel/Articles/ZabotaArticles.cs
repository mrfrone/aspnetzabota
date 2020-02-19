using System;

namespace aspnetzabota.Content.Datamodel.Articles
{
    public class ZabotaArticles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IMG { get; set; }
        public DateTimeOffset Date { get; set; }
        public int CategoryID { get; set; }
        public virtual ZabotaCategory Category { get; set; }
    }
}
