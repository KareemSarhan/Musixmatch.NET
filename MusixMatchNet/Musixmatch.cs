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
        public double page_size { get; set; } = 10;
        /// <summary>
        /// 
        /// </summary>
        public double page { get; set; } = 1;

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
        public List<Album> GetArtistAlbums(String artist_id, String s_release_date = "asc", String g_album_name = "")
        {
            String url = Get_url($"artist.albums.get?format={_format}&callback={_callback}&artist_id={artist_id}&s_release_date={s_release_date}&g_album_name={g_album_name}&page_size={page_size}&page={page}");
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
    }
}