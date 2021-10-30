using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Galytix.WebApi.Model;
using System.Collections.Generic;
using Galytix.WebApi.Model;
using System.IO;
using System.Text;
using CsvHelper;
using Galytix.WebApi.Mappers;
using System.Linq;
using System;
using TinyCsvParser;
using Galytix.WebApi.Mapper;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("/api/gwp")]
    public class CountryGwpController : ControllerBase
    {
        public IConfiguration Configuration;
        public CountryGwpController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("avg")]
        public async Task<IActionResult> Avg([FromBody] QueryData Query)
        {
            try
            {
                string currentDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string country = Query.country;
                string[] lobs = Query.lob.Split(',');
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
                GwpMap csvMapper = new GwpMap();
                CsvParser<Gwp> csvParser = new CsvParser<Gwp>(csvParserOptions, csvMapper);
                //   string dataSource = Configuration["DataSource"];  Due to time constraint couldn't move dataSource to config
                var result = csvParser
                            .ReadFromFile(currentDir + "\\Data\\gwpByCountry.csv", Encoding.ASCII)
                             .ToList();
                
                List<Gwp> Rows = new List<Gwp>();  // Rows will store the csv rows 
                foreach (var details in result) Rows.Add(details.Result);

                int nonNullData;
                Dictionary<string, float?> dict = new Dictionary<string, float?>();
      
                for (int i = 0; i < lobs.Length; i++){  // checking for each lineOfBusiness
                    nonNullData = 0 ;
                    var rates = Rows
                                .Where(r => r.country == country && r.lineOfBusiness == lobs[i])
                                .Select(g => new { sum= GetTotalSum(g,out nonNullData)});
                    float? avg= rates.ElementAt(0).sum/nonNullData;
                    dict.Add(lobs[i], avg);
                 }
                // converting the dictionary to json here
                var entries = dict.Select(d => string.Format("\"{0}\":[{1}]", d.Key, string.Format("{0:N4}",d.Value)));
                string json1 = "{" + string.Join(",", entries) + "}";
                return Ok(json1);
            }
            catch(Exception ex)
            {
                int a = 2;
            }
            return Ok("Error");
        }

        private static float GetTotalSum(Gwp Obj, out int num)
        {
            float? sum = 0;
            num = 0;
            if (Obj.Y2000 != null) { sum += Obj.Y2000; num++; }
            if (Obj.Y2001 != null) { sum += Obj.Y2001; num++; }
            if (Obj.Y2002 != null) { sum += Obj.Y2002; num++; }
            if (Obj.Y2003 != null) { sum += Obj.Y2003; num++; }
            if (Obj.Y2004 != null) { sum += Obj.Y2004; num++; }
            if (Obj.Y2005 != null) { sum += Obj.Y2005; num++; }
            if (Obj.Y2006 != null) { sum += Obj.Y2006; num++; }
            if (Obj.Y2007 != null) { sum += Obj.Y2007; num++; }
            if (Obj.Y2008 != null) { sum += Obj.Y2008; num++; }
            if (Obj.Y2009 != null) { sum += Obj.Y2009; num++; }
            if (Obj.Y2010 != null) { sum += Obj.Y2010; num++; }
            if (Obj.Y2011 != null) { sum += Obj.Y2011; num++; }
            if (Obj.Y2012 != null) { sum += Obj.Y2012; num++; }
            if (Obj.Y2013 != null) { sum += Obj.Y2013; num++; }
            if (Obj.Y2014 != null) { sum += Obj.Y2014; num++; }
            if (Obj.Y2015 != null) { sum += Obj.Y2015; num++; }
            return (float)sum;
        }
    }
}
