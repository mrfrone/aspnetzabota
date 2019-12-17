using System.ComponentModel.DataAnnotations;

namespace aspnetzabota.Content.Database.Entities
{
    public class Review
    {
        public int? id { get; set; }
        public string author { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string email { get; set; }
        public string text { get; set; }
        public string date { get; set; }
    }
}
