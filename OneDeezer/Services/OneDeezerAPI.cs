using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using SQLite.Net.Attributes;
using OneDeezer.Data;

namespace OneDeezer.Services
{
    public class OneDeezerAPI
    {
        class ArtistEqualityComparer : IEqualityComparer<Artist>
        {
            public bool Equals(Artist x, Artist y)
            {
                return x.id == y.id;
            }

            public int GetHashCode(Artist obj)
            {
                return obj.GetHashCode();
            }
        }

        public async Task<List<OneDeezerSearchResult>> search(string text)
        {
            using (var client = new HttpClient())
            {
 

                try
                {
                    var jsonResult = await client.GetStringAsync("https://api.deezer.com/search?q=" + Uri.EscapeUriString(text));
                   var response= JsonConvert.DeserializeObject<OneDeezerSearchResponse>(jsonResult);



                    //Met en cache les Artistes résultats
                    //using (var db = new OneDBContext())
                    //{
                    //    foreach (var artist in response.data.Select(d => d.artist).Distinct())
                    //    {
                    //        var id = artist.id;
                    //        if (!db.Table<Artist>().Where(a => a.id == id).Any())
                    //        {
                    //            try
                    //            {
                    //                db.Insert(artist);
                    //            }
                    //            catch (Exception e)
                    //            {
                    //                Debug.WriteLine(e.ToString());
                    //            }
                    //        }
                    //    }
                    //}



                    return response.data;
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
        [Indexed]
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
