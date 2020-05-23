namespace MusixmatchNet
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class RawJson
    {
        [JsonProperty("message")]
        public _Message _Message { get; set; }
    }

    public class _Message
    {
        [JsonProperty("header")]
        public _Header _Header { get; set; }

        [JsonProperty("body")]
        public _Body _Body { get; set; }
    }

    public class _Body
    {
        [JsonProperty("album_list")]
        public List<_AlbumList> _AlbumList { get; set; }

        [JsonProperty("album")]
        public _Album _Album { get; set; }

        [JsonProperty("subtitle")]
        public _Subtitle _Subtitle { get; set; }

        [JsonProperty("artist_list")]
        public List<_ArtistList> _ArtistList { get; set; }

        [JsonProperty("artist")]
        public _Artist _Artist { get; set; }

        [JsonProperty("track_list")]
        public List<_TrackList> _TrackList { get; set; }

        [JsonProperty("track")]
        public _Track _Track { get; set; }
    }

    public class _ArtistList
    {
        [JsonProperty("artist")]
        public _Artist _Artist { get; set; }
    }

    public class _Artist
    {
        [JsonProperty("artist_credits")]
        public _ArtistCredits _ArtistCredits { get; set; }

        [JsonProperty("artist_mbid")]
        public string _ArtistMbid { get; set; }

        [JsonProperty("artist_name")]
        public string _ArtistName { get; set; }

        [JsonProperty("secondary_genres")]
        public _SecondaryGenres _SecondaryGenres { get; set; }

        [JsonProperty("artist_alias_list")]
        public List<_ArtistAliasList> _ArtistAliasList { get; set; }

        [JsonProperty("artist_vanity_id")]
        public string _ArtistVanityId { get; set; }

        [JsonProperty("restricted")]
        public long _Restricted { get; set; }

        [JsonProperty("artist_country")]
        public string _ArtistCountry { get; set; }

        [JsonProperty("artist_comment")]
        public string _ArtistComment { get; set; }

        [JsonProperty("artist_name_translation_list")]
        public List<_ArtistNameTranslationList> _ArtistNameTranslationList { get; set; }

        [JsonProperty("artist_edit_url")]
        public string _ArtistEditUrl { get; set; }

        [JsonProperty("artist_share_url")]
        public string _ArtistShareUrl { get; set; }

        [JsonProperty("artist_id")]
        public long _ArtistId { get; set; }

        [JsonProperty("updated_time")]
        public string _UpdatedTime { get; set; }

        [JsonProperty("managed")]
        public long _Managed { get; set; }

        [JsonProperty("primary_genres")]
        public _PrimaryGenres _PrimaryGenres { get; set; }

        [JsonProperty("artist_twitter_url")]
        public string _ArtistTwitterUrl { get; set; }

        [JsonProperty("artist_rating")]
        public long _ArtistRating { get; set; }
    }

    public partial class _TrackList
    {
        [JsonProperty("track")]
        public _Track _Track { get; set; }
    }

    public partial class _Track
    {
        [JsonProperty("track_id")]
        public long _TrackId { get; set; }

        [JsonProperty("track_name")]
        public string _TrackName { get; set; }

        [JsonProperty("track_name_translation_list")]
        public List<_TrackNameTranslationList> _TrackNameTranslationList { get; set; }

        [JsonProperty("track_rating")]
        public long _TrackRating { get; set; }

        [JsonProperty("commontrack_id")]
        public long _CommontrackId { get; set; }

        [JsonProperty("instrumental")]
        public long _Instrumental { get; set; }

        [JsonProperty("explicit")]
        public long _Explicit { get; set; }

        [JsonProperty("has_lyrics")]
        public long _HasLyrics { get; set; }

        [JsonProperty("has_subtitles")]
        public long _HasSubtitles { get; set; }

        [JsonProperty("has_richsync")]
        public long _HasRichsync { get; set; }

        [JsonProperty("num_favourite")]
        public long _NumFavourite { get; set; }

        [JsonProperty("album_id")]
        public long _AlbumId { get; set; }

        [JsonProperty("album_name")]
        public string _AlbumName { get; set; }

        [JsonProperty("artist_id")]
        public long _ArtistId { get; set; }

        [JsonProperty("artist_name")]
        public string _ArtistName { get; set; }

        [JsonProperty("track_share_url")]
        public Uri _TrackShareUrl { get; set; }

        [JsonProperty("track_edit_url")]
        public Uri _TrackEditUrl { get; set; }

        [JsonProperty("restricted")]
        public long _Restricted { get; set; }

        [JsonProperty("updated_time")]
        public DateTimeOffset _UpdatedTime { get; set; }

        [JsonProperty("primary_genres")]
        public _PrimaryGenres _PrimaryGenres { get; set; }

        [JsonProperty("secondary_genres")]
        public _PrimaryGenres _SecondaryGenres { get; set; }
    }

    public class _TrackNameTranslationList
    {
        [JsonProperty("language")]
        public string _Language { get; set; }

        [JsonProperty("translation")]
        public string _Translation { get; set; }
    }

    public class _ArtistAliasList
    {
        [JsonProperty("artist_alias")]
        public string _ArtistAlias { get; set; }
    }

    public class _ArtistCredits
    {
        [JsonProperty("artist_list")]
        public List<_ArtistList> _ArtistList { get; set; }
    }

    public class _ArtistNameTranslationList
    {
        [JsonProperty("artist_name_translation")]
        public _ArtistNameTranslation _ArtistNameTranslation { get; set; }
    }

    public class _ArtistNameTranslation
    {
        [JsonProperty("language")]
        public string _Language { get; set; }

        [JsonProperty("translation")]
        public string _Translation { get; set; }
    }

    public class _Subtitle
    {
        [JsonProperty("subtitle_body")]
        public string _SubtitleBody { get; set; }

        [JsonProperty("publisher_list")]
        public List<string> _PublisherList { get; set; }

        [JsonProperty("subtitle_language")]
        public string _SubtitleLanguage { get; set; }

        [JsonProperty("subtitle_language_description")]
        public string _SubtitleLanguageDescription { get; set; }

        [JsonProperty("subtitle_id")]
        public long _SubtitleId { get; set; }

        [JsonProperty("pixel_tracking_url")]
        public string _PixelTrackingUrl { get; set; }

        [JsonProperty("html_tracking_url")]
        public string _HtmlTrackingUrl { get; set; }

        [JsonProperty("restricted")]
        public long _Restricted { get; set; }

        [JsonProperty("lyrics_copyright")]
        public string _LyricsCopyright { get; set; }

        [JsonProperty("script_tracking_url")]
        public string _ScriptTrackingUrl { get; set; }

        [JsonProperty("subtitle_length")]
        public long _SubtitleLength { get; set; }

        [JsonProperty("updated_time")]
        public string _UpdatedTime { get; set; }

        [JsonProperty("writer_list")]
        public List<string> _WriterList { get; set; }
    }

    public class _AlbumList
    {
        [JsonProperty("album", NullValueHandling = NullValueHandling.Ignore)]
        public _Album _Album { get; set; }
    }

    public class _Album
    {
        [JsonProperty("album_id")]
        public long _AlbumId { get; set; }

        [JsonProperty("album_mbid")]
        public string _AlbumMbid { get; set; }

        [JsonProperty("album_name")]
        public string _AlbumName { get; set; }

        [JsonProperty("album_rating")]
        public long _AlbumRating { get; set; }

        [JsonProperty("album_release_date")]
        public string _AlbumReleaseDate { get; set; }

        [JsonProperty("artist_id")]
        public long _ArtistId { get; set; }

        [JsonProperty("artist_name")]
        public string _ArtistName { get; set; }

        [JsonProperty("primary_genres")]
        public _PrimaryGenres _PrimaryGenres { get; set; }

        [JsonProperty("secondary_genres")]
        public _PrimaryGenres _SecondaryGenres { get; set; }

        [JsonProperty("album_pline")]
        public string _AlbumPline { get; set; }

        [JsonProperty("album_copyright")]
        public string _AlbumCopyright { get; set; }

        [JsonProperty("album_label")]
        public string _AlbumLabel { get; set; }

        [JsonProperty("restricted")]
        public long _Restricted { get; set; }

        [JsonProperty("updated_time")]
        public DateTimeOffset _UpdatedTime { get; set; }

        [JsonProperty("album_coverart_100x100")]
        public string _AlbumCoverart100X100 { get; set; }
    }

    public class _PrimaryGenres
    {
        [JsonProperty("music_genre_list")]
        public List<_MusicGenreList> _MusicGenreList { get; set; }
    }

    public class _SecondaryGenres
    {
        [JsonProperty("music_genre_list")]
        public List<_MusicGenreList> _MusicGenreList { get; set; }
    }

    public class _MusicGenreList
    {
        [JsonProperty("music_genre")]
        public _MusicGenre _MusicGenre { get; set; }
    }

    public class _MusicGenre
    {
        [JsonProperty("music_genre_id")]
        public long _MusicGenreId { get; set; }

        [JsonProperty("music_genre_parent_id")]
        public long _MusicGenreParentId { get; set; }

        [JsonProperty("music_genre_name")]
        public string _MusicGenreName { get; set; }

        [JsonProperty("music_genre_name_extended")]
        public string _MusicGenreNameExtended { get; set; }

        [JsonProperty("music_genre_vanity")]
        public string _MusicGenreVanity { get; set; }
    }

    public class _Header
    {
        [JsonProperty("status_code")]
        public long _StatusCode { get; set; }

        [JsonProperty("execute_time")]
        public long _ExecuteTime { get; set; }

        [JsonProperty("available")]
        public long _Available { get; set; }
    }

    internal static class _Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}