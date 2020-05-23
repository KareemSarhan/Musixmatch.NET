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
        public String apiToken, url = "http://api.musixmatch.com/ws/1.1/";
        String _format { get; set; } = "json";
        String _callback { get; set; } = "callback";
        public double page_size { get; set; } = 10;

        public double page { get; set; } = 1;

        HttpClient _httpclient = new HttpClient();
        public Musixmatch(String apiToken)
        {
            this.apiToken = apiToken;
        }
        public Musixmatch(String apiToken, String url)
        {
            this.apiToken = apiToken;
            this.url = url;
        }
        public String Get_url(String url)
        {
            return this.url + url + String.Format("&apikey={0}", this.apiToken);
        }
        public async Task<string> RequestAsync(String url)
        {
            return await _httpclient.GetStringAsync(url);
        }

    }
}