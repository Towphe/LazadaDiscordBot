using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LazadaDiscordBot.LazadaAccessFiles;

namespace LazadaDiscordBot.DiscordAccessFiles
{
    public interface IMessageFormatter
    {
        Task SendMessage(List<Product> productResults=null);
    }
}
