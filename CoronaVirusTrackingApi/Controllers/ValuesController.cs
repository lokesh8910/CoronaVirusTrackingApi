using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoronaVirusWebScapper;

namespace CoronaVirusTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            WorldCasesInfo cases;
            CaseProcessor processor = new CaseProcessor(new WorldCasesInfo());
            string url = "https://www.worldometers.info/coronavirus/";
            cases = processor.GetCasesInfo(url, string.Empty);
            return Ok(cases);
        }

        // GET api/values/5
        [HttpGet("{country}")]
        public IActionResult Get(string country)
        {
            WorldCasesInfo cases;
            CaseProcessor processor = new CaseProcessor(new CountryCaseInfo());
            string url = "https://www.worldometers.info/coronavirus/country/"+country;
            cases = processor.GetCasesInfo(url,country);
            return Ok(cases);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
