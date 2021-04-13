using Galaxies.Common;
using Galaxies.Core.Contracts;
using Galaxies.IO.Contracts;
using Galaxies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galaxies.Commands.CommandImplementations
{
    public class PrintCommand : CommandWithArgs
    {
        private readonly IWriter writer;
        private readonly IUnitOfWork unitOfWork;

        public PrintCommand(IList<string> args, IWriter writer, IUnitOfWork unitOfWork)
            : base(args)
        {
            this.writer = writer;
            this.unitOfWork = unitOfWork;
        }

        public override void Execute()
        {
            string galaxyName = this.Args[0].TrimBrackets();
            Galaxy galaxy = this.unitOfWork.Galaxies.FirstOrDefault(x => x.Name == galaxyName);

            if (galaxy != null)
            {
                this.writer.WriteLine(galaxy);
            }
        }
    }
}
