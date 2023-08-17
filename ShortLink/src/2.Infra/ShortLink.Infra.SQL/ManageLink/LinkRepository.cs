using ShortLink.Contracts.DAL.ManageLink;
using ShortLink.Domain.ManageLink.Entities;

namespace ShortLink.Infra.SQL.ManageLink
{
    public class LinkRepository : ILinkRepository
    {
        private readonly LinkDbContext _dbContext;

        public LinkRepository(LinkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Link link)
        {
            _dbContext.Links.Add(link);
            _dbContext.SaveChanges();
        }

        public Link? Get(string shortUrl) => _dbContext.Links.SingleOrDefault(l => l.ShortUrl == shortUrl);
    }
}
