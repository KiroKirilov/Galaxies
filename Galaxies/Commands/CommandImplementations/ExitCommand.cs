using Galaxies.Commands.Contracts;
using System;

namespace Galaxies.Commands.CommandImplementations
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
