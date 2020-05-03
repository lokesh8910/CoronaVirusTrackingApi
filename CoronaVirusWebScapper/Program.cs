using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.IO;
using System.Globalization;

namespace CoronaVirusWebScapper
{
    class Program
    {
        static void Main(string[] args)
        {
            WorldCasesInfo cases;
            CaseProcessor processor;
            string url;
            string countryName = string.Empty;
            if (args.Length == 0)
            {
                processor = new CaseProcessor(new WorldCasesInfo());
                url = "https://www.worldometers.info/coronavirus/";
            }
            else
            {
                processor = new CaseProcessor(new CountryCaseInfo());
                url = "https://www.worldometers.info/coronavirus/country/" + args[0];
                countryName = args[0];
            }

            cases = processor.GetCasesInfo(url, countryName);
            Console.WriteLine("Total Cases:" + cases.TotalCases);
            Console.WriteLine("Deaths:" + cases.Deaths);
            Console.WriteLine("Recovered:" + cases.Recovered);
            //Console.ReadLine();

        }

        
    }
}
