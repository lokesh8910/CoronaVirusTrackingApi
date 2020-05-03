using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.IO;
using System.Globalization;

namespace CoronaVirusWebScapper
{
    public class WebScarpper : IWebScrapper
    {
        private static ScrapingBrowser _browser = new ScrapingBrowser();
        public WorldCasesInfo GetCasesInfo(HtmlNode htmlNode, WorldCasesInfo casesInfo)
        {
            var selectNodes = htmlNode.OwnerDocument.DocumentNode.SelectNodes("//div[@id='maincounter-wrap']");

            foreach (var node in selectNodes)
            {
                string header = node.ChildNodes["h1"].InnerText;
                if (header.Equals("Coronavirus Cases:"))
                {
                    casesInfo.TotalCases = Convert.ToDouble(node.ChildNodes["div"].InnerText);
                }
                else if (header.Equals("Deaths:"))
                {
                    casesInfo.Deaths = Convert.ToDouble(node.ChildNodes["div"].InnerText);
                }
                else
                {
                    casesInfo.Recovered = Convert.ToDouble(node.ChildNodes["div"].InnerText);
                }
            }

            return casesInfo;
        }

        public HtmlNode GetHtml(string url)
        {
            WebPage webpage = _browser.NavigateToPage(new Uri(url));
            return webpage.Html;
        }
    }
}
