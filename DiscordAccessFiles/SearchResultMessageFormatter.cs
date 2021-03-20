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
    class SearchResultMessageFormatter
    {
        private MessageCreateEventArgs ctx;
        public SearchResultMessageFormatter(MessageCreateEventArgs c)
        {
            ctx = c;
        }
        public async void SendProducts(List<Product> productResults)
        {
            // Format this in a good looking way
            string message = "";
            foreach (Product p in productResults)
            {
                message += $"Product: {p.ProductName}, Price: {p.Price}\n";
            }
            var msg = await new DiscordMessageBuilder().WithContent($"{message}").SendAsync(ctx.Channel);
        }
    }
}
