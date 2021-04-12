using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Models
{
    public class Star : BaseModel
    {
        public double Mass { get; set; }

        public double Luminosity { get; set; }

        public double Size { get; set; }

        public int Temp { get; set; }
    }
}
