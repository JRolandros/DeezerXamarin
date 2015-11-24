using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace OneDeezer.Services
{
    public class OneDeezerAPI
    {
        public async Task<List<OneDeezerSearchResult>> search(string text)
        {
            using (var client = new HttpClient())
            {
 

                try
                {
                    var jsonResult = await client.GetStringAsync("https://api.deezer.com/search?q=" + Uri.EscapeUriString(text));
                   var dsr = JsonConvert.DeserializeObject<OneDeezerSearchResponse>(jsonResult);
                    return dsr.data;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(" Error getting http result: "+e.Message);
                    return new List<OneDeezerSearchResult>();
                }
                
            }
            
                

        }
    }

    public class Artist
    {
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string picture { get; set; }
        public string picture_small { get; set; }
        public string picture_medium { get; set; }
        public string picture_big { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }

    public class Album
    {
        public string id { get; set; }
        public string title { get; set; }
        public string cover { get; set; }
        public string cover_small { get; set; }
        public string cover_medium { get; set; }
        public string cover_big { get; set; }
        public string tracklist { get; set; }
        public string type { get; set; }
    }

    public class OneDeezerSearchResult
    {
        public string id { get; set; }
        public bool readable { get; set; }
        public string title { get; set; }
        public string title_short { get; set; }
        public string title_version { get; set; }
        public string link { get; set; }
        public string duration { get; set; }
        public string rank { get; set; }
        public bool explicit_lyrics { get; set; }
        public string preview { get; set; }
        public Artist artist { get; set; }
        public Album album { get; set; }
        public string type { get; set; }
    }

    public class OneDeezerSearchResponse
    {
        public List<OneDeezerSearchResult> data { get; set; }
        public int total { get; set; }
        public string next { get; set; }
    }

}
