using ShortLink.Domain.ManageLink.Entities;

namespace ShortLink.Contracts.DAL.ManageLink
{
    public interface ILinkRepository
    {
        string Get(string shortUrl);
        void Create(Link link);

    }
}
