using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object text)
        {
            Console.WriteLine(text);
        }
    }
}
