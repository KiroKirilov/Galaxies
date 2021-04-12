using Galaxies.Common;
using Galaxies.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Commands.CommandImplementations
{
    public class AddCommand : AbstractCommand
    {
        private readonly IUnitOfWork unitOfWork;

        public AddCommand(IList<string> args, IUnitOfWork unitOfWork)
            : base(args)
        {
            this.unitOfWork = unitOfWork;
        }

        public override void Execute()
        {
            string entityType = this.Args[0];
            switch (entityType.ToLower())
            {
                case Constants.EntityTypes.Galaxy:
                    this.AddGalaxy();
                    break;

                default:
                    break;
            }
        }

        private void AddGalaxy()
        {
            string name = this.Args[1];
            string type = this.Args[2];
            string ageString = this.Args[3];

            this.unitOfWork.AddGalaxy(name, type, ageString);
        }
    }
}
