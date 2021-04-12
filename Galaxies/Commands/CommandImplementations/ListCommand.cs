using Galaxies.Common;
using Galaxies.Core.Contracts;
using Galaxies.IO.Contracts;
using Galaxies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Commands.CommandImplementations
{
    public class ListCommand : CommandWithArgs
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWriter writer;

        public ListCommand(IList<string> args, IUnitOfWork unitOfWork, IWriter writer)
            : base(args)
        {
            this.unitOfWork = unitOfWork;
            this.writer = writer;
        }

        public override void Execute()
        {
            string entityType = this.Args[0];
            switch (entityType.ToLower())
            {
                case Constants.EntityTypesPlural.Galaxies:
                    this.PrintEntities(this.unitOfWork.Galaxies, Constants.EntityTypesPlural.Galaxies);
                    break;

                case Constants.EntityTypesPlural.Stars:
                    this.PrintEntities(this.unitOfWork.Stars, Constants.EntityTypesPlural.Stars);
                    break;

                case Constants.EntityTypesPlural.Planets:
                    this.PrintEntities(this.unitOfWork.Planets, Constants.EntityTypesPlural.Planets);
                    break;

                case Constants.EntityTypesPlural.Moons:
                    this.PrintEntities(this.unitOfWork.Moons, Constants.EntityTypesPlural.Moons);
                    break;

                default:
                    break;
            }
        }

        private void PrintEntities(IEnumerable<BaseModel> entities, string label)
        {
            this.writer.WriteLine($"--- List of all researched {label} ---");

            foreach (BaseModel entity in entities)
            {
                this.writer.WriteLine(entity.Name);
            }

            this.writer.WriteLine($"--- End of {label} list ---");
        }
    }
}
