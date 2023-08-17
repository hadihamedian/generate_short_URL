using ShortLink.Domain.ManageLink.Entities;

namespace ShortLink.Contracts.DAL.ManageLink
{
    public interface ILinkRepository
    {
        Link? Get(string shortUrl);
        void Create(Link link);

    }
}
