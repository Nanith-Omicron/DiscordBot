using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class config
    {

        private const string configfolder = "res";
        private const string configfile = "conf";

        static config()
        {

        }

    }



}

public struct configInfo
{
    public string token;
    public string cmdprefix;

}