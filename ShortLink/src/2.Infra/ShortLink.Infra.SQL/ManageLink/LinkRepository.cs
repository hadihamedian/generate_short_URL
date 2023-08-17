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

        public Link? GetByToken(string token) => _dbContext.Links.SingleOrDefault(l => l.Token == token);

        public void Update(Link link)
        {
            _dbContext.Links.Update(link);
            _dbContext.SaveChanges();
        }
    }
}
