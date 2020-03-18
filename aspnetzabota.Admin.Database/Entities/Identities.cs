using System;

namespace aspnetzabota.Admin.Database.Entities
{
    public class Identities
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedById { get; set; }
        public DateTimeOffset? Deleted { get; set; }


    }
}
