using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordBot
{
 
    public class Brap : ModuleBase
    {

        [Command("brap")]
        public async Task  brap([Summary("How many brap")] int lenght = 0)
        {
            await ReplyAsync("What a pungent smell, darling.");

        }


        [Command("braap")]
        public async Task braap([Summary("How many brap")] int lenght = 0)
        {
                await ReplyAsync("Oh dear, is that Eggs? Hmmm, I can smell yesterday dinner");

        }

        [Command("braaap")]
        public async Task braaap([Summary("How many brap")] int lenght = 0)
        {
            await ReplyAsync("Hmmmm, OOH! That take me off guard....Ah yes..I can almost tastes it.....");

        }


        [Command("yt")]
        public async Task yt([Remainder][Summary("Youtube this")] string f)
        {
           
            await ReplyAsync( await helpa.YoutubeThatShit(f));

        }

        [Command("ryt")]
        public async Task ryt([Remainder][Summary("Youtube this, Randomely")] int f = 1)
        {
            var e = helpa.GetRandomWord(f);
            Console.WriteLine(e);

            await ReplyAsync(await helpa.YoutubeThatShit(e));

        }


        [Command("fj")]
        public async Task fj([Remainder][Summary("Youtube this")] string f = "")
        {
           
            await ReplyAsync(helpa.Autism());

        }
        [Command("source")]
        public async Task source([Remainder][Summary("Youtube this")] string f = "")
        {

            await Program.SendImage("C:/Users/Nanov/Pictures/Reaction/source.png");

        }

    }
}
