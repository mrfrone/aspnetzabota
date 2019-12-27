using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetzabota.Admin.Database.Entities
{
    public class Jwts
    {
        public virtual int Id { get; set; }

        public virtual string Token { get; set; }

        public virtual DateTimeOffset Expires { get; set; }

        public virtual DateTimeOffset Issued { get; set; }

        public virtual DateTimeOffset? Deleted { get; set; }

        public virtual bool IsDeleted { get; set; }

        [ForeignKey(nameof(Identity))]
        public virtual int IdentityId { get; set; }
        public virtual Identities Identity { get; set; }

        [ForeignKey(nameof(DeletedBy))]
        public virtual int? DeletedById { get; set; }
        public virtual Identities DeletedBy { get; set; }
    }
}
