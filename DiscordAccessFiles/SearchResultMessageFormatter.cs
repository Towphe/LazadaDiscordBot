using System;
using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;
using System.Text;
using LazadaDiscordBot.LazadaAccessFiles;

namespace LazadaDiscordBot.DiscordAccessFiles
{
    class SearchResultMessageFormatter : IMessageFormatter
    {
        private MessageCreateEventArgs ctx;
        public SearchResultMessageFormatter(MessageCreateEventArgs c)
        {
            ctx = c;
        }
        public Task SendMessage(List<Product> productResults, MessageCreateEventArgs e)
        {
            return Task.Run(() =>
            {
                e.Message.RespondAsync("Search Completed! Found:");
                for (int i=0; i<3; i++)
                {
                    DiscordEmbed embed = new DiscordEmbedBuilder()
                    {
                        Title = $"{i + 1} : {productResults[i].ProductName.Remove(productResults[i].ProductName.Length/2, (productResults[i].ProductName.Length-1)-(productResults[i].ProductName.Length/2))}",
                        Url = productResults[i].Url
                    }.Build();
                    string message = $"{i+1}. Product: {productResults[i].ProductName}\nPrice: {productResults[i].Price}\n\n";
                    var msg = new DiscordMessageBuilder().WithContent($"{message}").WithEmbed(embed).SendAsync(ctx.Channel);
                }
            });
            // Format this in a good looking way
        }
    }
}
