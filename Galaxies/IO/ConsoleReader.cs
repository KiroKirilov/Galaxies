using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
