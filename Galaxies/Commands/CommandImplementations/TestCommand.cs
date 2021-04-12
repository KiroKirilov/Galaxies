using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Commands.CommandImplementations
{
    public class TestCommand : AbstractCommand
    {
        private readonly IWriter writer;
        public TestCommand(IList<string> args, IWriter writer)
            : base(args)
        {
            this.writer = writer;
        }

        public override void Execute()
        {
            foreach (var arg in this.Args)
            {
                this.writer.WriteLine(arg);
            }
        }
    }
}
