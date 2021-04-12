using Galaxies.Core.Contracts;
using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Commands.CommandImplementations
{
    public class StatsCommand : CommandWithArgs
    {
        private readonly IWriter writer;
        private readonly IUnitOfWork unitOfWork;

        public StatsCommand(IList<string> args, IWriter writer, IUnitOfWork unitOfWork)
            : base(args)
        {
            this.writer = writer;
            this.unitOfWork = unitOfWork;
        }

        public override void Execute()
        {
            this.writer.WriteLine("--- Stats ---");

            this.writer.WriteLine($"Galaxies: {this.unitOfWork.GalaxiesCount}");
            this.writer.WriteLine($"Stars: {this.unitOfWork.StarsCount}");
            this.writer.WriteLine($"Planets: {this.unitOfWork.PlanetsCount}");
            this.writer.WriteLine($"Moons: {this.unitOfWork.MoonsCount}");

            this.writer.WriteLine("--- End of stats ---");
        }
    }
}
