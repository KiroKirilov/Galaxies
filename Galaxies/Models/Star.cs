using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Models
{
    public class Star : BaseModel
    {
        private readonly IList<Planet> planets = new List<Planet>();

        public double Mass { get; set; }

        public double Luminosity { get; set; }

        public double Size { get; set; }

        public int Temp { get; set; }

        public string Class => "G";

        public ICollection<Planet> Planets => this.planets;

        public void AddPlanet(Planet planet)
        {
            this.planets.Add(planet);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {this.Name}");
            builder.AppendLine($"\t  Class: {this.Class} ({this.Mass}, {this.Size}, {this.Temp}, {this.Luminosity})");
            if (this.planets.Count == 0)
            {
                builder.AppendLine($"\t  Planets: none");
            }
            else
            {
                builder.AppendLine("\t  Planets:");
                foreach (Planet planet in this.planets)
                {
                    builder.AppendLine($"\t\to {planet}");
                }
            }

            return builder.ToString();
        }
    }
}
