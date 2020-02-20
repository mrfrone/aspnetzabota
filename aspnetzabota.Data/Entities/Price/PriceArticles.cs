using aspnetzabota.Content.Database.Entities;

namespace aspnetzabota.Content.Datamodel.Price
{
    public class ZabotaPriceArticles
    {
        public int? Id { get; set; }
        public int? PriceId { get; set; }
        public Articles Article { get; set; }
    }
}
