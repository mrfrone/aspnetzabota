using aspnetzabota.Content.Datamodel.Articles;

namespace aspnetzabota.Content.Datamodel.Price
{
    public class ZabotaPrice
    {
            public int Id { get; set; }
            public int Code { get; set; }
            public string DepartName { get; set; }
            public string GroupSeo { get; set; }
            public int GroupCode { get; set; }
            public string GroupName { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
            public string Tags { get; set; }
            public ZabotaArticles Article { get; set; }
    }
}
