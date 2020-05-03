using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusWebScapper
{
    public interface IWebScrapper
    {
        HtmlNode GetHtml(string url);

        WorldCasesInfo GetCasesInfo(HtmlNode node,WorldCasesInfo casesInfo);
    }
}
