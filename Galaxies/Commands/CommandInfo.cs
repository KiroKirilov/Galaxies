using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Commands
{
    public class CommandInfo
    {
        public string Name { get; set; }

        public IList<string> Args { get; set; }
    }
}
