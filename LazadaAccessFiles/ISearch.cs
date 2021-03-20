using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using System.Text;

namespace LazadaDiscordBot.LazadaAccessFiles
{
    interface ISearch
    {
        IWebDriver Connect();
        List<Product> Search(string query, IWebDriver driver);
    }
}
