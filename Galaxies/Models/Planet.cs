using Galaxies.Common;
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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Name: {this.Name}");
            builder.AppendLine($"\t\t  Type: {this.Type}");
            builder.AppendLine($"\t\t  Support life: {(this.SupportsLife ? Constants.SupportsLifeTrueValue : Constants.SupportsLifeFalseValue)}");
            if (this.moons.Count == 0)
            {
                builder.AppendLine($"\t\t  Moons: none");
            }
            else
            {
                builder.AppendLine("\t\t  Moons:");
                foreach (Moon moon in this.moons)
                {
                    builder.AppendLine($"\t\t\t▪ {moon}");
                }
            }

            return builder.ToString();
        }
    }
}
