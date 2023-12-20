
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace TestDom.Data
{
    internal class Meteo
    {
        public float Temperature {get; set; }
        public string Description { get; set; }
        public float WindSpeed { get; set; }
        public Meteo(float temperature, string description, float windSpeed) {
            Temperature = temperature;
            Description = description;
            WindSpeed = windSpeed; 
        }
        public Meteo() { }
    }
}
