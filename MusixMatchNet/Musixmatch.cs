using System.Threading.Tasks;
using System;
using System.Net.Http;
using MusixmatchNet;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MusixmatchNet
{
    public class Musixmatch
    {
        /// <summary>
        /// 
        /// </summary>
        public String apiToken;
        /// <summary>
        /// 
        /// </summary>
        public String url = "http://api.musixmatch.com/ws/1.1/";
        /// <summary>
        /// 
        /// </summary>
        String _format { get; set; } = "json";
        /// <summary>
        /// 
        /// </summary>
        String _callback { get; set; } = "callback";
        /// <summary>
        /// 
        /// </summary>
        public double? Page_size { get; set; } = 10;
        /// <summary>
        /// 
        /// </summary>
        public double? Page { get; set; } = 1;

        HttpClient _httpclient = new HttpClient();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiToken"></param>
        public Musixmatch(String apiToken)
        {
            this.apiToken = apiToken;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiToken"></param>
        /// <param name="url"></param>
        public Musixmatch(String apiToken, String url)
        {
            this.apiToken = apiToken;
            this.url = url;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public String Get_url(String url)
        {
            return this.url + url + String.Format("&apikey={0}", this.apiToken);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> RequestAsync(String url)
        {
            return await _httpclient.GetStringAsync(url);
        }
        /// <summary>
        /// Get the album discography of an artist.
        /// </summary>
        /// <param name="artist_id">Musixmatch artist id.</param>
        /// <param name="s_release_date">Sort by release date (asc|desc).</param>
        /// <param name="g_album_name">Group by Album Name.</param>
        /// <returns></returns>
        public List<Album> GetArtistAlbums(String artist_id, String s_release_date = "asc", String g_album_name = null)
        {
            String url = Get_url($"artist.albums.get?format={_format}&callback={_callback}&artist_id={artist_id}&s_release_date={s_release_date}&g_album_name={g_album_name}&page_size={Page_size}&page={Page}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.FromRawJsonToAlbumList(RawJson);
        }
        /// <summary>
        /// Get the Album object using the musixmatch id.
        /// </summary>
        /// <param name="album_id">The musiXmatch album id.</param>
        /// <returns></returns>
        public Album GetAlbum(String album_id)
        {
            String url = Get_url($"album.get?format={_format}&callback={_callback}&album_id={album_id}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.From_AlbumToAlbum(RawJson._Message._Body._Album);
        }
        /// <summary>
        /// Get an artist chart.
        /// <para>
        /// Artist chart is a chart of the  top artists within a given country.
        /// </para>
        /// </summary>
        /// <param name="country">A valid country code (default US).</param>
        /// <returns></returns>
        public List<Artist> GetArtistsChart(String country= "US")
        {
            String url = Get_url($"chart.artists.get?format={_format}&callback={_callback}&page={Page}&page_size={Page_size}&country={country}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.FromRawJsonToArtistList(RawJson);
        }
        /// <summary>
        /// Gets the artist data using artist_id .
        /// </summary>
        /// <param name="artist_id">Musixmatch artist id</param>
        /// <returns></returns>
        public Artist GetArtist(String artist_id)
        {
            String url = Get_url($"artist.get?format={_format}&callback={_callback}&artist_id={artist_id}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.From_ArtistToArtist(RawJson._Message._Body._Artist);
        }
        /// <summary>
        /// Returns Artists with names containing the ArtistName.
        /// </summary>
        /// <param name="PartialArtistName">The Artist name you want to search with/for.</param>
        /// <param name="f_artist_id">Musixmatch artist id.</param>
        /// <returns></returns>
        public List<Artist> SearchArtist(String PartialArtistName, double? f_artist_id= null)
        {
            String url = Get_url($"artist.search?format={_format}&callback={_callback}&q_artist={PartialArtistName}&f_artist_id={f_artist_id}&page={Page}&page_size={Page_size}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.FromRawJsonToArtistList(RawJson);
        }
        /// <summary>
        /// Get related artists.
        /// </summary>
        /// <param name="artist_id">The musiXmatch artist id</param>
        /// <returns>A list of artists somehow related to a given one.</returns>
        public List<Artist> GetRelatedArtist(String artist_id)
        {
            String url = Get_url($"artist.related.get?format={_format}&callback={_callback}&artist_id={artist_id}&page_size={Page_size}&page={Page}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.FromRawJsonToArtistList(RawJson);
        }
        /// <summary>
        /// Get the songs of an album.
        /// </summary>
        /// <param name="album_id">The musiXmatch album id.</param>
        /// <param name="f_has_lyrics">When set, filter only contents with lyrics.</param>
        /// <returns></returns>
        public List<Track> GetAlbumTracks(String album_id,String f_has_lyrics = null)
        {
            String url = Get_url($"album.tracks.get?format={_format}&callback={_callback}&album_id={album_id}&f_has_lyrics={f_has_lyrics}&page={Page}&page_size={Page_size}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.FromRawJsonToTrackList(RawJson);
        }
        /// <summary>
        /// Match your song against our database.
        /// </summary>
        /// <param name="q_artist">The song artist</param>
        /// <param name="q_track">The song title</param>
        /// <param name="f_has_lyrics">When set, filter only contents with lyrics.</param>
        /// <param name="f_has_subtitle">When set, filter only contents with subtitle.</param>
        /// <returns></returns>
        public Track GetMatcherTrack(String q_artist = null, String q_track = null, double? f_has_lyrics = null, double? f_has_subtitle = null)
        {
            String url = Get_url($"matcher.track.get?format={_format}&callback={_callback}&q_artist={q_track}&q_track={q_track}&f_has_lyrics={f_has_lyrics}&f_has_subtitle={f_has_subtitle}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.From_TrackToTrack(RawJson._Message._Body._Track);
        }
        /// <summary>
        /// Get a song by Musixmatch id
        /// </summary>
        /// <param name="track_id">The Musixmatch commontrack id.</param>
        /// <returns></returns>
        public Track GetTrack(String track_id )
        {
            String url = Get_url($"track.get?format={_format}&callback={_callback}&track_id={track_id}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.From_TrackToTrack(RawJson._Message._Body._Track);
        }
        /// <summary>
        /// Get top ten tracks for an artist orderd by track rating.
        /// </summary>
        /// <param name="q_track">The song title</param>
        /// <param name="q_artist">The song artist</param>
        /// <param name="q_lyrics">Any word in the lyrics</param>
        /// <param name="f_artist_id">When set, filter by this artist id.</param>
        /// <param name="f_music_genre_id">When set, filter by this music category id</param>
        /// <param name="f_lyrics_language">Filter by the lyrics language (en,it,..)</param>
        /// <param name="f_has_lyrics">When set, filter only contents with lyrics</param>
        /// <param name="s_artist_rating">Sort by our popularity index for artists (asc|desc)</param>
        /// <param name="s_track_rating">Sort by our popularity index for tracks (asc|desc)</param>
        /// <param name="quorum_factor">Search only a part of the given query string.Allowed range is (0.1 � 0.9)</param>
        /// <returns></returns>
        public List<Track> SearchTrack(String q_track = null, String q_artist = null, String q_lyrics = null, double? f_artist_id = null, double? f_music_genre_id = null, double? f_lyrics_language = null, double? f_has_lyrics = null, string s_artist_rating = null, string s_track_rating = null, double? quorum_factor = null)
        {
            String url = Get_url($"track.search?format={_format}&callback={_callback}&q_track={q_track}&q_artist={q_artist}&q_lyrics={q_lyrics}&f_artist_id={f_artist_id}&f_music_genre_id={f_music_genre_id}&f_lyrics_language={f_lyrics_language}&f_has_lyrics={f_has_lyrics}&s_artist_rating={s_artist_rating}&s_track_rating={s_track_rating}&quorum_factor={quorum_factor}&page_size={Page_size}&page={Page}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.FromRawJsonToTrackList(RawJson);
        }
        /// <summary>
        /// Get a song chart.
        /// </summary>
        /// <param name="country">A valid 2 letters country code (default US). Set XW as worldwide</param>
        /// <param name="chart_name">
        /// Select among available charts:
        /// top : editorial chart
        /// hot : Most viewed lyrics in the last 2 hours
        /// mxmweekly : Most viewed lyrics in the last 7 days
        /// mxmweekly_new : Most viewed lyrics in the last 7 days limited to new releases only</param>
        /// <param name="f_has_lyrics">When set, filter only contents with lyrics</param>
        /// <returns></returns>
        public List<Track> GetTracksChart(string country,String chart_name =null, string f_has_lyrics = null)
        {
            String url = Get_url($"chart.tracks.get?format={_format}&callback={_callback}&chart_name={chart_name}&page={Page}&page_size={Page_size}&country={country}&f_has_lyrics={f_has_lyrics}");
            String response = RequestAsync(url).Result;
            StatusCode.CheckResponse(response);
            RawJson RawJson = JsonConvert.DeserializeObject<RawJson>(response);
            return ReturnJson.FromRawJsonToTrackList(RawJson);
        }
        public String match_lyrics(String track, String artist)
        {
            return this.url + String.Format("matcher.lyrics.get?format=jsonp&callback=callback&q_track={0}&q_artist={1}&apikey={2}", track, artist, this.apiToken);
        }
        public String lyrics_get(String track_id)
        {
            return this.url + String.Format("track.lyrics.get?format=jsonp&callback=callback&track_id={0}&apikey={1}", track_id, this.apiToken);
        }
        public String match_lyrics(String track, String artist)
        {
            return this.url + String.Format("matcher.lyrics.get?format=jsonp&callback=callback&q_track={0}&q_artist={1}&apikey={2}", track, artist, this.apiToken);
        }
        public String lyrics_get(String track_id)
        {
            return this.url + String.Format("track.lyrics.get?format=jsonp&callback=callback&track_id={0}&apikey={1}", track_id, this.apiToken);
        }
        public static void Main(String[] Args) { }
    }
}