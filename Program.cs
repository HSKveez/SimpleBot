using System.Threading.Tasks;
using SimpleBot.Commands;
using SimpleBot.Config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;

namespace SimpleBot
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }
        
        static async Task Main()
        {
            var configLoader = new ConfigLoader();//Конфиг (нагло спизженный с мануала и немного переработанный)
            await configLoader.LoadConfig();
            
            var botConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = configLoader.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(botConfig);

            Client.Ready += ClientReady;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { configLoader.Prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = true
            };

            Commands = Client.UseCommandsNext(commandsConfig);
            
            //Регистрация команд
            Commands.RegisterCommands<UtilityCommands>();
            
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task ClientReady(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}