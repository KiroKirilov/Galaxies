using Galaxies.Common;
using Galaxies.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Galaxies.Commands.CommandImplementations
{
    public class AddCommand : CommandWithArgs
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

                case Constants.EntityTypes.Star:
                    this.AddStar();
                    break;

                case Constants.EntityTypes.Planet:
                    this.AddPlanet();
                    break;

                case Constants.EntityTypes.Moon:
                    this.AddMoon();
                    break;

                default:
                    break;
            }
        }

        private void AddGalaxy()
        {
            string name = this.Args[1].TrimBrackets();
            string type = this.Args[2];
            (double age, string ageSuffix) parsedAge = this.ParseAgeString(this.Args[3]);

            this.unitOfWork.AddGalaxy(name, type, parsedAge.age, parsedAge.ageSuffix);
        }

        private void AddStar()
        {
            string galaxyName = this.Args[1].TrimBrackets();
            string starName = this.Args[2].TrimBrackets();
            double mass = double.Parse(this.Args[3]);
            double size = double.Parse(this.Args[4]);
            int temp = int.Parse(this.Args[5]);
            double luminosity = double.Parse(this.Args[6]);

            this.unitOfWork.AddStar(starName, galaxyName, mass, size, temp, luminosity);
        }

        private void AddPlanet()
        {
            string starName = this.Args[1].TrimBrackets();
            string planetName = this.Args[2].TrimBrackets();
            string type = this.Args[3];
            bool supportsLife = string.Equals(this.Args[4], Constants.SupportsLifeTrueValue, StringComparison.OrdinalIgnoreCase);

            this.unitOfWork.AddPlanet(planetName, starName, type, supportsLife);
        }

        private void AddMoon()
        {
            string planetName = this.Args[1].TrimBrackets();
            string moonName = this.Args[2].TrimBrackets();

            this.unitOfWork.AddMoon(moonName, planetName);
        }

        private (double age, string ageSuffix) ParseAgeString(string ageString)
        {
            char suffix = ageString[ageString.Length - 1];
            double age = double.Parse(ageString.TrimEnd(suffix));
            return (age, suffix.ToString());
        }
    }
}
