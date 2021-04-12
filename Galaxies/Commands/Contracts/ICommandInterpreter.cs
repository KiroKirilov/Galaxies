using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Commands.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand CreateCommand(string commandName, IList<string> args);
    }
}
