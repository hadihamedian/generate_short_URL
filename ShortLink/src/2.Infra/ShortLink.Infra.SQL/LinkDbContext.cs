using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.ManageLink.Entities;

namespace ShortLink.Infra.SQL
{
    public class LinkDbContext : DbContext
    {
        public LinkDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }

     
    }
}
