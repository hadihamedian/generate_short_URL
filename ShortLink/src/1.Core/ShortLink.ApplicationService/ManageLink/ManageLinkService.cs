using ShortLink.Contracts.DAL.ManageLink;
using ShortLink.Domain.ManageLink.Entities;
using ShortLink.Utilities.Helpers;

namespace ShortLink.ApplicationService.ManageLink
{
    public class ManageLinkService
    {
        private readonly ILinkRepository _linkRepository;

        public ManageLinkService(ILinkRepository linkRepository) 
        {
            _linkRepository = linkRepository;
        }

        #region Public Methods
        public string Create(string baseUrl, string url)
        {
            if (!Validation(url)) return string.Empty;

            Link link = new()
            {
                FullUrl = url,
                NumberOfVisit = 1,
                ShortUrl = url.Substring(url.LastIndexOf('/') + 1),
                Token = UrlHelper.GenerateTokenUrl(baseUrl, url)
            };

            _linkRepository.Create(link);

            return link.Token;
        }

        public string GetValidFullUrl(string tokenUrl)
        {
            if (!Validation(tokenUrl)) return string.Empty;

            var link = _linkRepository.GetByToken(tokenUrl);
            
            if (link == null) return string.Empty;

            link.NumberOfVisit += 1;
            _linkRepository.Update(link);

            return link.FullUrl;
        }

        #endregion


        #region Private Methods
        private static bool Validation(string url)
        {
            if (!UrlHelper.IsValidUrl(url)) return false;

            return true;
        }
        #endregion


    }
}
