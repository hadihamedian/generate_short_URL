using ShortLink.Domain.ManageLink.Entities;

namespace ShortLink.Contracts.DAL.ManageLink
{
    public interface ILinkRepository
    {
        Link? GetByToken(string shortUrl);
        void Create(Link link);
        void Update(Link link);
    }
}
