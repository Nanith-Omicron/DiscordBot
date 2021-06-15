using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;


namespace DiscordBot
{
    class helpa
    {
        
        static string CurrentPath = "C:/Users/Nanov/source/repos/DiscordBot/DiscordBot";
        private static Dictionary<string, string> reply;
        static helpa()
        {
            string json = File.ReadAllText(CurrentPath + "/json/alerts.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            reply = data;
          
        }
    
      public  static string Getreply(string t)
        {
            if (reply.ContainsKey(t)) return reply[t];
            return "";
        }

        public static string checkSynonym(string t)
        {
            word x;

            if (word.Words.ContainsKey(t)) x = word.Words[t];
            
           var w = AccessWebsites("http://www.thesaurus.com/browse/", t);
             string[] s = {};
            if (w == null) { checkSynonym(t); return "FUCK"; }
            
            if(w.Contains("INITIAL_STATE ="))
            {

                var encoded = WebUtility.HtmlEncode(w);
                s = w.Split(new string[] { "INITIAL_STATE =" }, StringSplitOptions.None);
                w = encoded;

                Console.WriteLine(s);

                return w;
             
            }
    

            if (s.Length > 0)
                return w;
            else return "ERROR";
        }
        public static string AccessWebsites(string website, string query = "")
        {
            var web = website;
            if (!web.Contains("www")) web = "www." + web + ".com";
            if (query != "" && query != " ")
            {
                if (web[web.Length - 1] == '/') web += query;
                else web += "/" + query;
            }
      
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(web);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                TextReader reader = new StreamReader(response.GetResponseStream());
                string text = reader.ReadToEnd();
                return text;
            }
            else {Console.WriteLine("Unable to access " + web + " -Error:" + response.StatusCode);   return null; }

        }
        public const string YOUTUBEAPI = "XXXXXXXXX";
        public static string GetRandomWord(int a = 1)
        {
            var f = "";
            for (int i = 0; i < a; i++) {
                if (i > 0) f += " ";
                f += helpa.AccessWebsites("https://www.randomword.com/").Split(new string[] { "<div id=\"random_word\">" }, StringSplitOptions.None)[1].Split(new string[] { "<" }, StringSplitOptions.None)[0];
            }
            return f;
          
        }
        public async static Task<string> YoutubeThatShit(string query)
        {
            var e = new YouTubeService(new Google.Apis.Services.BaseClientService.Initializer() {ApiKey = YOUTUBEAPI });
            var sr = e.Search.List("snippet");          
            sr.Q = query;
            sr.MaxResults = 20;
            var g = sr.Execute();
            if (g.Items.Count == 0) {

               await Program.SendImage("C:/Users/Nanov/Pictures/Reaction/NOT OKAY.jpg");
                return "`" + query + "` yield no result.";
            } 
            if (g== null || g.Items[0].Id.VideoId == null) return "I didn't found anything :(.";     
            return "https://www.youtube.com/watch?v=" + g.Items[0].Id.VideoId.ToString();
        }
        public static string meaningOfWords(string t)
        {
            var website = "https://en.wikipedia.org/wiki/" + t;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(website);

            return "";
        }
        public static string Autism()
        {
            var e = "";
            //TODO HTML PARSER
            e = helpa.AccessWebsites("https://www.funnyjunk.com/content/random").Split(new string[] { "<a class=\"contentContainer\" style=\"max-width: " }, StringSplitOptions.None)[1]
                .Split(new string[] { "href=" }, StringSplitOptions.None)[1].Split('"')[1];
            return e;
        }

        public static word AnalyzeWord(string t)
        {

            var e = new word(t);
            return e;
        }
    }

    public struct Emotion
    {
        public string Name;
        public float value;
    }


}
