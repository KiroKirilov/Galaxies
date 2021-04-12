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

        public ICollection<Planet> Planets => this.planets;

        public void AddPlanet(Planet planet)
        {
            this.planets.Add(planet);
        }
    }
}
