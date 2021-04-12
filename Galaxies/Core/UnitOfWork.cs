using Galaxies.Core.Contracts;
using Galaxies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galaxies.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IList<Galaxy> galaxies = new List<Galaxy>();

        public IEnumerable<Galaxy> Galaxies 
        { 
            get { return this.galaxies; }
        }

        public int StarsCount { get; private set; }

        public int GalaxiesCount => this.galaxies.Count;

        public void AddGalaxy(string name, string type, string ageString)
        {
            (double age, string ageSuffix) parsedAge = this.ParseAgeString(ageString);
            Galaxy galaxy = new Galaxy
            {
                Name = this.RemoveBracketsFromName(name),
                Type = type,
                Age = parsedAge.age,
                AgeSuffix = parsedAge.ageSuffix
            };

            this.galaxies.Add(galaxy);
        }

        public void AddStar(string starName, string galaxyName, double mass, double size, int temp, double luminosity)
        {
            Star star = new Star
            {
                Name = this.RemoveBracketsFromName(starName),
                Luminosity = luminosity,
                Mass = mass,
                Size = size,
                Temp = temp
            };

            Galaxy galaxy = this.galaxies.FirstOrDefault(x => x.Name == this.RemoveBracketsFromName(galaxyName));
            if (galaxy != null)
            {
                galaxy.AddStar(star);
                this.StarsCount++;
            }
        }

        private string RemoveBracketsFromName(string name)
        {
            return name.Trim('[', ']');
        }

        private (double age, string ageSuffix) ParseAgeString(string ageString)
        {
            char suffix = ageString[ageString.Length - 1];
            double age = double.Parse(ageString.TrimEnd(suffix));
            return (age, suffix.ToString());
        }
    }
}
