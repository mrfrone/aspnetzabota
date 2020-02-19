using System;

namespace aspnetzabota.Content.Datamodel.Review
{
    public class ZabotaReview
    {
        public int? Id { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
