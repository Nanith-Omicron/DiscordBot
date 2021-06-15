using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord.WebSocket;
using Discord.Commands;
using System.IO;
using Discord;

 
namespace DiscordBot
{
    class Program
    {
        public const string CONTRYHOME = "NOT SHOWING";
        public const char CMDTOKEN = '`';
        public const ulong NanithOmicron = 0;


        public DiscordSocketClient _client;
        private CommandService _cmd;
        private IServiceProvider _service;
    public async Task MainAsync()
    {
            _client = new DiscordSocketClient();
            _cmd = new CommandService();
            _service = new ServiceCollection().BuildServiceProvider();
            await InstallCommandsAsync();
            _client.Log += Log;
         
       

            await _client.LoginAsync(TokenType.Bot, CONTRYHOME);
        await _client.StartAsync();
        await Task.Delay(-1);
    }
        public async Task InstallCommandsAsync()
        {      
            _client.MessageReceived += HandleCommandAsync;
            _cmd.AddTypeReader(typeof(String[]), new stringreader());
            await _cmd.AddModulesAsync(Assembly.GetEntryAssembly());
        }



        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.Delay(1);
        }
        public static SocketCommandContext _ct;
        public static async Task SendImage(string path)
        {
            await _ct.Channel.SendFileAsync(path);
        }
        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            
            var message = messageParam as SocketUserMessage;
            if (message == null) return;     
            int argPos = 0;
          
            if (!((message.HasCharPrefix(CMDTOKEN, ref argPos) || (message.HasCharPrefix('\'', ref argPos) )|| message.HasMentionPrefix(_client.CurrentUser, ref argPos)))) return;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;
            _ct = context;
            var result = await _cmd.ExecuteAsync(context, argPos, _service);
    
            if (!result.IsSuccess)
            {

                if (message.Author.Id == NanithOmicron)
                    await context.Channel.SendMessageAsync("Error: " +result.ErrorReason);
                else await context.Channel.SendMessageAsync("I didn't understand that Sweety~");
            }
        }

        static void LinkStart()
             => new Program().MainAsync().GetAwaiter().GetResult();
        static void Main(string[] args)
        {
            
            LinkStart();
            
            Console.Read();
        }
        
    }
}
