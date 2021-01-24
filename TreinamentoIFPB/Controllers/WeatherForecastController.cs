using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RepositoryIFPB.Model;
using RepositoryIFPB.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TreinamentoIFPB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
/*        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };*/

        private readonly ILogger<WeatherForecastController> _logger;

        private ServiceIFPB serviceIFPB;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            /*           string json = System.IO.File.ReadAllText(@"C:\Users\adria\Documents\Curso.NET\IFPB.txt");
                       var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);

                       return list.ToArray();*/

            return (IEnumerable<WeatherForecast>)serviceIFPB.Get();

            /*            var rng = new Random();
                        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = rng.Next(-20, 55),
                            Summary = Summaries[rng.Next(Summaries.Length)]
                        })
                        .ToArray();*/

        }

        [HttpPost]
        public IActionResult Post([FromBody] JObject json)
        {
            var model = JsonConvert.DeserializeObject<WeatherForecast>(json.ToString());
            string line;

            try
            {
                using (StreamReader file = new StreamReader(@"C:\Users\adria\Documents\Curso.NET\IFPB.txt"))
                {
                    while ((line = file.ReadToEnd()) != null)
                    {
                        if (line.Contains("]"))
                        {
                            line = line.Replace("]", ",");
                            break;
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Users\adria\Documents\Curso.NET\IFPB.txt", true))
                {
                    writer.WriteLine(json + "]");
                    return Ok("Deu tudo certo");
                    //return StatusCode(200);
                }

            }catch (Exception ex)
            {
                return Problem("Ocorreu um erro" + ex.Message);
            }
        }
    }
}
