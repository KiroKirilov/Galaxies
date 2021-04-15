using Galaxies.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Models
{
    public class Galaxy : BaseModel
    {
        private readonly IList<Star> stars = new List<Star>();

        public string Type { get; set; }

        public double Age { get; set; }

        public string AgeSuffix { get; set; }

        public ICollection<Star> Stars => this.stars;

        public void AddStar(Star star)
        {
            this.stars.Add(star);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"--- Data for {this.Name} galaxy ---");
            builder.AppendLine($"Type: {this.Type}");
            builder.AppendLine($"Age: {this.Age}{this.AgeSuffix}");
            if (this.stars.Count == 0)
            {
                builder.AppendLine($"Stars: none");
            }
            else
            {
                builder.AppendLine("Stars:");
                foreach (Star star in this.stars)
                {
                    builder.AppendLine($"\t- {star}");
                    builder.TrimEnd();
                    builder.AppendLine();
                }
            }

            builder.Append($"--- End of data for {this.Name} galaxy ---");

            return builder.ToString();
        }
    }
}
