using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaVirusWebScapper
{
    public class CaseProcessor
    {
        private WorldCasesInfo _caseInfo;
        private IWebScrapper webScrapper;

        public CaseProcessor(WorldCasesInfo casesInfo)
        {
            this._caseInfo = casesInfo;
            this.webScrapper = new WebScarpper();
        }
        public WorldCasesInfo GetCasesInfo(string url,string countryName)
        {
            var htmlnode = webScrapper.GetHtml(url);

            _caseInfo = webScrapper.GetCasesInfo(htmlnode, _caseInfo);

            if(_caseInfo.GetType() == typeof(CountryCaseInfo))
            {
                ((CountryCaseInfo)_caseInfo).CountryName = countryName;
            }

            return _caseInfo;
        }
    }
}
