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
    }
}
