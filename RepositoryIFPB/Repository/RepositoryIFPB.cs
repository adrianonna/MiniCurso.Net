using Newtonsoft.Json;
using RepositoryIFPB.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryIFPB.Repository
{
    public class RepositoryIFPB : ServiceIFPB
    {
        public object Get()
        {
            string json = System.IO.File.ReadAllText(@"C:\Users\adria\Documents\Curso.NET\IFPB.txt");
            var list = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
            return null;
        }

        public object Post(string json)
        {
            return null;
        }
    }
}
