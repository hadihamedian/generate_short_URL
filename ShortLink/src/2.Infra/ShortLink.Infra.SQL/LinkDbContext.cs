using Microsoft.EntityFrameworkCore;
using ShortLink.Domain.ManageLink.Entities;

namespace ShortLink.Infra.SQL
{
    public class LinkDbContext : DbContext
    {
        public DbSet<Link> Links { get; set; }
    }
}
