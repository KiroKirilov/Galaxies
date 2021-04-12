using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(object text);
    }
}
