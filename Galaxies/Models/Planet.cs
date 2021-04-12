using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Models
{
    public class Planet : BaseModel
    {
        private readonly IList<Moon> moons = new List<Moon>();

        public string Type { get; set; }

        public bool SupportsLife { get; set; }

        public ICollection<Moon> Moons => this.moons;

        public void AddMoon(Moon moon)
        {
            this.moons.Add(moon);
        }
    }
}
