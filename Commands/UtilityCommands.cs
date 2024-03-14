using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using SimpleBot.Message;

namespace SimpleBot.Commands
{
    public class UtilityCommands : BaseCommandModule
    {
        readonly EmbedMessageSystem _messageSystem = new EmbedMessageSystem();
        
        [Command("status")]//Выводит количество пользователей на сервере
        public async Task StatusCommand(CommandContext ctx)
        {
            await _messageSystem.SendEmbedMessage("Статус сервера", $"Текущее число пользователей: {ctx.Guild.MemberCount}", ctx);
        }
    }
}