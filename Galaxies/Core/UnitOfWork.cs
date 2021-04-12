using Galaxies.Core.Contracts;
using Galaxies.Models;
using System;
using System.Collections.Generic;
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
