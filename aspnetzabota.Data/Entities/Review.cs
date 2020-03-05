using System;

namespace aspnetzabota.Content.Database.Entities
{
    public class Review
    {
        public int? Id { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
        public bool IsModerated { get; set; }
    }
}
