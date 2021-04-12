using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Core
{
    public class CommandInfo
    {
        public string Name { get; set; }

        public IList<string> Args { get; set; }
    }
}
