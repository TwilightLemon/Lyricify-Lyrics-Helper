using System.Globalization;

namespace Lyricify.Lyrics.Searchers.Helpers
{
    public static class ArtworkHelper
    {
        public static string? NormalizeUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            var value = url!.Trim();
            if (value.StartsWith("//", StringComparison.Ordinal)) value = "https:" + value;
            if (value.Contains('{') || value.Contains('}')) return null;
            return Uri.TryCreate(value, UriKind.Absolute, out var uri) &&
                   (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                ? value
                : null;
        }

        public static string? FirstUrl(IEnumerable<string?>? urls) =>
            urls?.Select(NormalizeUrl).FirstOrDefault(url => url is not null);

        public static string? WithSize(string? url, int width = 600, int height = 600) =>
            NormalizeUrl(url?
                .Replace("{w}", width.ToString(CultureInfo.InvariantCulture))
                .Replace("{h}", height.ToString(CultureInfo.InvariantCulture))
                .Replace("{size}", width.ToString(CultureInfo.InvariantCulture)));
    }
}
