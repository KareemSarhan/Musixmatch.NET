using System.Threading.Tasks;
using System;
using System.Net.Http;

namespace Musixmatch.NET
{
    public class Musixmatch
    {
        public String apiToken, url;
        public Musixmatch(String apiToken, String url)
        {
            this.apiToken = apiToken;
            this.url = url;
        }

    }
}