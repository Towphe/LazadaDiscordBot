using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System.Text;

namespace LazadaDiscordBot.DiscordAccessFiles
{
    class HelpMessageFormat : IMessageFormatter
    {
        private MessageCreateEventArgs ctx;
        public HelpMessageFormat(MessageCreateEventArgs c)
        {
            ctx = c;
        }
        public async void SendMessage()
        {
            // Format this in a good looking way
            var msg = await new DiscordMessageBuilder().WithContent($"LazBotPH is a discord bot that allows you to search Lazada thru Discord! To search, kindly type: !lazsearch [product]").SendAsync(ctx.Channel);
        }
    }
}
