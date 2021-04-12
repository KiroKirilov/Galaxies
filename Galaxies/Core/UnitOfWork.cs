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
        private readonly IList<Star> stars = new List<Star>();
        private readonly IList<Planet> planets = new List<Planet>();
        private readonly IList<Moon> moons = new List<Moon>();

        public IEnumerable<Galaxy> Galaxies 
        { 
            get { return this.galaxies; }
        }

        public IEnumerable<Star> Stars
        {
            get { return this.stars; }
        }

        public IEnumerable<Planet> Planets
        {
            get { return this.planets; }
        }

        public IEnumerable<Moon> Moons
        {
            get { return this.moons; }
        }

        public int GalaxiesCount => this.galaxies.Count;
        public int StarsCount => this.stars.Count;
        public int PlanetsCount => this.planets.Count;
        public int MoonsCount => this.moons.Count;

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
                // we keep two copies of the same ref for convinience sake
                galaxy.AddStar(star);
                this.stars.Add(star);
            }
        }

        public void AddPlanet(string planetName, string starName, string type, bool supportsLife)
        {
            Planet planet = new Planet
            {
                Name = this.RemoveBracketsFromName(planetName),
                Type = type,
                SupportsLife = supportsLife
            };

            Star star = this.stars.FirstOrDefault(x => x.Name == this.RemoveBracketsFromName(starName));

            if (star != null)
            {
                star.AddPlanet(planet);
                this.planets.Add(planet);
            }
        }

        public void AddMoon(string moonName, string planetName)
        {
            Moon moon = new Moon
            {
                Name = this.RemoveBracketsFromName(moonName)
            };

            Planet planet = this.planets.FirstOrDefault(x => x.Name == this.RemoveBracketsFromName(planetName));

            if (planet != null)
            {
                planet.AddMoon(moon);
                this.moons.Add(moon);
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
