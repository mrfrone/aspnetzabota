using Microsoft.EntityFrameworkCore;
using aspnetzabota.Admin.Database.Entities;

namespace aspnetzabota.Admin.Database.Context
{
    public class AdminContext : DbContext
    {
        public const string SchemaName = "zabota_admin";
        public AdminContext(DbContextOptions<AdminContext> options) : base(options) { }

        public DbSet<Identities> Identities { get; set; }
        public DbSet<Jwts> Jwts { get; set; }

    }
}
