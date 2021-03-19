﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using LazadaDiscordBot.DiscordAccessFiles;

namespace LazadaDiscordBot
{
    class Program
    {
        private IConfiguration AppConfiguration;
        public Program(IConfiguration configService)
        {
            AppConfiguration = configService;
        }

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        
        static async Task MainAsync()
        {
            
            var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").AddUserSecrets("appsettings.json").AddUserSecrets<Program>().Build();
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = config.GetSection("DiscordLoginInfo")["DiscToken"],
                TokenType = TokenType.Bot
            });

            // Change this into an external function
            discord.MessageCreated += (s, e) =>
            {
                _ = Task.Run(async () =>
                {
                    if (e.Message.Content.Contains("!lazhelp"))
                    {
                        IMessageFormatter formatter = new HelpMessageFormat(e);
                        formatter.SendMessage();
                        GC.Collect();
                    }
                });
                return Task.CompletedTask;
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        // Make this work
        /*private async Task MessageHandler(DiscordClient s, MessageCreateEventArgs e)
        {
            if (e.Message.Content.Contains("!lazhelp"))
            {
                new HelpMessageFormat(e).SendMessage();
            }
        }*/
    }
}