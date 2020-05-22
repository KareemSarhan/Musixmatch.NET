using System.Threading.Tasks;
using System;
using System.Net.Http;

namespace Musixmatch.NET
{
    public class Musixmatch
    {
        public String apiToken, url = "http://api.musixmatch.com/ws/1.1/";
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
            return this.url + url + String.Format("&apikey={0}",this.apiToken);
        }
    }
}