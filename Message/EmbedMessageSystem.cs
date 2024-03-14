using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace SimpleBot.Message
{
    public class EmbedMessageSystem
    {
        public async Task SendEmbedMessage(string title, string description, CommandContext ctx)
        {
            var message = new DiscordEmbedBuilder()
            {
                Title = title,
                Description = description,
                Color = new Optional<DiscordColor>(10563365)
            };
            
            await ctx.Message.DeleteAsync();
            await ctx.Channel.SendMessageAsync(embed: message);
        }
    }
}