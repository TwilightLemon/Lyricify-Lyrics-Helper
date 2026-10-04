using Newtonsoft.Json;

namespace Lyricify.Lyrics.Providers.Web.Spotify
{
#nullable disable
    public class SearchResponse
    {
        [JsonProperty("tracks")]
        public SearchTracks Tracks { get; set; }
    }

    public class SearchTracks
    {
        [JsonProperty("items")]
        public List<SearchTrackItem> Items { get; set; }
    }

    public class SearchTrackItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }

        [JsonProperty("artists")]
        public List<SearchArtistItem> Artists { get; set; }

        [JsonProperty("album")]
        public SearchAlbumItem Album { get; set; }
    }

    public class SearchAlbumItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artists")]
        public List<SearchArtistItem> Artists { get; set; }

        [JsonProperty("images")]
        public List<SearchImageItem> Images { get; set; }
    }

    public class SearchImageItem
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }
    }

    public class SearchArtistItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class SpotifyTrackCandidate
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public int? DurationMs { get; set; }

        public string ArtworkUrl { get; set; }
    }
}
