using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Text;

namespace LazadaDiscordBot.LazadaAccessFiles
{
    public class LazSearch : ISearch
    {
        public IWebDriver Connect()
        {
            IWebDriver driver = new ChromeDriver("C://WebDriver/bin");
            driver.Navigate().GoToUrl(@"https://www.lazada.com.ph");
            return driver;
        }
        public List<Product> Search(string query, IWebDriver driver)
        {
            List<Product> products = ProcessLastSearch(query, driver).Result;
            return products;
        }
        public static Task<List<Product>> ProcessLastSearch(string query, IWebDriver driver)
        {
            return Task.Run(() => 
            {
                IWebElement SearchBarDiv = driver.FindElement(By.ClassName("search-box__bar--29h6"));
                IWebElement SearchBar = SearchBarDiv.FindElement(By.ClassName("search-box__input--O34g"));
                IWebElement SearchButton = driver.FindElement(By.ClassName("search-box__button--1oH7"));

                SearchBar.SendKeys(query + Keys.Enter);
                var DOMresults = driver.FindElements(By.ClassName("c2prKC")).ToList().Take(3);
                List<Product> productResults = new List<Product>();
                foreach (var result in DOMresults)
                {
                    productResults.Add(new Product()
                    {
                        ProductName = result.FindElement(By.ClassName("c16H9d")).Text,
                        Price = result.FindElement(By.ClassName("c3gUW0")).Text
                    });
                }
                driver.Quit();
                return productResults;
            });
        }
    }
}
