using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiscordBot
{
  
    class word
    {
        public static Dictionary<string,word> Words = new Dictionary<string, word>();
        public string key;
        public List<Emotion> emotions;
        public List<string> synonyme = new List<string>(),antonym = new List<string>();
        public bool mature = false;

        public word (string t)
        {
            key = t;
      
        }
    }
}
