using System;

namespace aspnetzabota.Data.Models
{
    public class Review
    {
        public int? id { get; set; }
        public string author { get; set; }
        public string email { get; set; }
        public string text { get; set; }
        public string date { get; set; }
    }
}
