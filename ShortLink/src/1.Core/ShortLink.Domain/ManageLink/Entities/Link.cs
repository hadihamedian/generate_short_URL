namespace ShortLink.Domain.ManageLink.Entities
{
    public class Link : BaseEntity
    {
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public string Token { get; set; }
        public int NumberOfVisit { get; set; }
    }
}
