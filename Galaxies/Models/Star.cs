using Galaxies.Common;
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

        public double SizeAsRadius => this.Size / 2;

        public int Temp { get; set; }

        public string Class => this.GetClass();

        public ICollection<Planet> Planets => this.planets;

        public void AddPlanet(Planet planet)
        {
            this.planets.Add(planet);
        }

        private string GetClass()
        {

            if (this.Temp.IsInRange(2400, 3700) &&
                this.Luminosity <= 0.08 &&
                this.Mass.IsInRange(0.08, 0.45) &&
                this.SizeAsRadius <= 0.7)
            {
                return StarClass.M.ToString();
            }

            if (this.Temp.IsInRange(3700, 5200) &&
                this.Luminosity.IsInRange(0.08, 0.6) &&
                this.Mass.IsInRange(0.45, 0.8) &&
                this.SizeAsRadius.IsInRange(0.7, 0.96))
            {
                return StarClass.K.ToString();
            }

            if (this.Temp.IsInRange(5200, 6000) &&
                this.Luminosity.IsInRange(0.6, 1.5) &&
                this.Mass.IsInRange(0.8, 1.04) &&
                this.SizeAsRadius.IsInRange(0.96, 1.15))
            {
                return StarClass.G.ToString();
            }

            if (this.Temp.IsInRange(6000, 7500) &&
                this.Luminosity.IsInRange(1.5, 5) &&
                this.Mass.IsInRange(1.04, 1.4) &&
                this.SizeAsRadius.IsInRange(1.15, 1.4))
            {
                return StarClass.F.ToString();
            }

            if (this.Temp.IsInRange(7500, 10000) &&
                this.Luminosity.IsInRange(5, 25) &&
                this.Mass.IsInRange(1.4, 2.1) &&
                this.SizeAsRadius.IsInRange(1.4, 1.8))
            {
                return StarClass.A.ToString();
            }

            if (this.Temp.IsInRange(10000, 30000) &&
                this.Luminosity.IsInRange(25, 30000) &&
                this.Mass.IsInRange(2.1, 16) &&
                this.SizeAsRadius.IsInRange(1.8, 6.6))
            {
                return StarClass.B.ToString();
            }

            if (this.Temp >= 30000 &&
                this.Luminosity >= 30000 &&
                this.Mass >= 16 &&
                this.Size >= 6.6)
            {
                return StarClass.O.ToString();
            }

            // this should not be possible in normal scenarios :)
            return StarClass.Unknown.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {this.Name}");
            builder.AppendLine($"\t  Class: {this.Class} ({this.Mass}, {this.SizeAsRadius}, {this.Temp}, {this.Luminosity:N2})");
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
