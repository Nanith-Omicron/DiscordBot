using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
namespace DiscordBot
{
    public class stringreader : TypeReader
    {
        public override Task<TypeReaderResult> Read(ICommandContext context, string input, IServiceProvider services)
        {
            string[] result = { input };
            var y = input.Split(' ');
            if(y.Length > 0)
            {
                result = new string[y.Length];
                for (int i = 0; i < y.Length; i++)
                {
                    result[i] = y[i];
                }
            }
           return Task.FromResult(TypeReaderResult.FromSuccess(result));
         
        }
    }
}
