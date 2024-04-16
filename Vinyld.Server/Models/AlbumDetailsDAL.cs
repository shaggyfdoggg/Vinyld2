using Newtonsoft.Json;
using System.Net;

namespace Vinyld.Server.Models
{
    public class AlbumDetailsDAL
    {
        public static AlbumDetailsModel GetAlbumResults(string album)//Adjust here
        {
            //adjust
            //setup
            string apiKey = Secret.apiKey;
            string Host = Secret.Host;
            string url = $"https://theaudiodb.p.rapidapi.com/searchalbum.php?s={album}";
            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.Headers.Add("X-RapidAPI-Key", apiKey);
            request.Headers.Add("X-RapidAPI-Host", Host);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Converting to json
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            //Adjust
            //Convert to C#
            //Install Newtonsoft.json
            AlbumDetailsModel result = JsonConvert.DeserializeObject<AlbumDetailsModel>(json);
            return result;
        }
    }
}
