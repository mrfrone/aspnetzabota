using System;

namespace aspnetzabota.Content.Database.Entities
{
    public class Articles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public DateTimeOffset Date { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
