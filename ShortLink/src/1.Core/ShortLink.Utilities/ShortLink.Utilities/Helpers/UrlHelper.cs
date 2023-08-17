using System.Text.RegularExpressions;

namespace ShortLink.Utilities.Helpers
{
    public static class UrlHelper
    {
        public static bool IsValidUrl(string url)
        {
            string strRegex = @"((http|https)://)(www.)?" +
                              "[a-zA-Z0-9@:%._\\+~#?&//=]" +
                              "{2,256}\\.[a-z]" +
                              "{2,6}\\b([-a-zA-Z0-9@:%" +
                              "._\\+~#?&//=]*)";

            Regex re = new(strRegex);

            if (re.IsMatch(url))
                return (true);
            else
                return (false);
        }

        public static string GenerateTokenUrl(string baseUrl, string url)
        {
            if (!IsValidUrl(baseUrl) || !IsValidUrl(url)) return string.Empty;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            Random random = new();

            return $"{baseUrl}/{new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray())}";
        }

    }
}
