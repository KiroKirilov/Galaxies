using Galaxies.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Commands.CommandImplementations
{
    public abstract class AbstractCommand : ICommand
    {
        public AbstractCommand(IList<string> args)
        {
            this.Args = args;
        }

        protected IList<string> Args { get; private set; }
        public abstract void Execute();
    }
}
