using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Models
{
    public class Moon : BaseModel
    {
        public override string ToString()
        {
            return this.Name;
        }
    }
}
