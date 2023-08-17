using System.Text;
using System.Text.RegularExpressions;
using System.Text.Unicode;

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

            string chars = Convert.ToBase64String(Encoding.UTF8.GetBytes(url)).ToString();

            Random random = new();

            return $"{baseUrl}/{new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray())}";
        }

    }
}
