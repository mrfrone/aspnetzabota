using aspnetzabota.Content.Datamodel.Articles;

namespace aspnetzabota.Content.Datamodel.Price
{
    public class ZabotaPriceArticles
    {
        public int? Id { get; set; }
        public int? PriceId { get; set; }
        public int? ArticleId { get; set; }
        public ZabotaArticles Article { get; set; }
    }
}
