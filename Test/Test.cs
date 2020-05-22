using System.Threading.Tasks;
using System;
using System.Net.Http;
using Musixmatch;
namespace Musixmatch.NET
{
    public class Test
    {            
        static async Task Main(string[] args)
        {
            //U shoud set your Musixmatch Api Token as an environment variable using 
            //Environment.SetEnvironmentVariable("MusixmatchApiToken", "YOUR API TOKEN",EnvironmentVariableTarget.User);
            Musixmatch X = new Musixmatch(Environment.GetEnvironmentVariable("MusixmatchApiToken"));
            HttpClient client = new HttpClient();
            // var responseString = await client.GetStringAsync("");
            Console.WriteLine(Environment.GetEnvironmentVariable("MusixmatchApiToken",EnvironmentVariableTarget.User));
        }

    }
}
