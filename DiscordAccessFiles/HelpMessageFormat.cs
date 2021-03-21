using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System.Text;
using LazadaDiscordBot.LazadaAccessFiles;

namespace LazadaDiscordBot.DiscordAccessFiles
{
    class HelpMessageFormat : IMessageFormatter
    {
        private MessageCreateEventArgs ctx;
        public HelpMessageFormat(MessageCreateEventArgs c)
        {
            ctx = c;
        }
        public Task SendMessage(List<Product> productList = null, MessageCreateEventArgs e = null)
        {
            return Task.Run(() => 
            {
                DiscordEmbed embed = new DiscordEmbedBuilder() { 
                    Title = "Link",
                    Url = "https://www.google.com"
                }.Build();
                var msg = new DiscordMessageBuilder().WithContent($"LazBotPH is a discord bot that allows you to search Lazada thru Discord! To search, kindly type: !lazsearch [product]\n\n").SendAsync(ctx.Channel);
                Console.WriteLine("Request : Help");
            });
            // Format this in a good looking way    
        }
    }
}
