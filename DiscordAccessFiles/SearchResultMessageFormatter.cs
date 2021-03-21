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
        public Task SendMessage(List<Product> productResults)
        {
            return Task.Run(() =>
            {
                string message = "";
                for (int i=0; i<3; i++)
                {
                    message += $"{i+1}. Product: {productResults[i].ProductName}\nPrice: {productResults[i].Price}\n\n";
                }
                var msg = new DiscordMessageBuilder().WithContent($"Found:\n\n{message}").SendAsync(ctx.Channel);
            });
            // Format this in a good looking way
        }
    }
}
