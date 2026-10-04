using Lyricify.Lyrics.Providers.Web.QQMusic;
using Lyricify.Lyrics.Searchers.Helpers;

namespace Lyricify.Lyrics.Searchers
{
    public class QQMusicSearchResult : ISearchResult
    {
        public ISearcher Searcher => new QQMusicSearcher();

        public QQMusicSearchResult(string title, string[] artists, string album, string[]? albumArtists, int durationMs, string id, string mid)
        {
            Title = title;
            Artists = artists;
            Album = album;
            AlbumArtists = albumArtists;
            DurationMs = durationMs;
            Id = id;
            Mid = mid;
        }

        public QQMusicSearchResult(Song song) : this(
            song.Title,
            song.Singer.Select(s => s.Name).ToArray(),
            song.Album.Title,
            null,
            song.Interval * 1000,
            song.Id,
            song.Mid
            )
        {
            ArtworkUrl = string.IsNullOrWhiteSpace(song.Album?.Mid)
                ? null
                : $"https://y.gtimg.cn/music/photo_new/T002R500x500M000{Uri.EscapeDataString(song.Album!.Mid)}.jpg";
        }

        public string Title { get; }

        public string[] Artists { get; }

        public string Album { get; }

        public string? ArtworkUrl { get; set; }

        public string Id { get; }

        public string Mid { get; }

        public string[]? AlbumArtists { get; }

        public int? DurationMs { get; }

        public CompareHelper.MatchType? MatchType { get; set; }
    }
}
