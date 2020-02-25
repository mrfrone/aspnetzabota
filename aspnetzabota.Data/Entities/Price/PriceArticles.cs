namespace aspnetzabota.Content.Database.Entities
{
    public class PriceArticles
    {
        public int? Id { get; set; }
        public int? PriceId { get; set; }
        public int? ArticleId { get; set; }
        public Articles Article { get; set; }
    }
}
