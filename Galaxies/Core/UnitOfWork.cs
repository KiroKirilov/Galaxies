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

        public void AddGalaxy(string name, string type, double age, string ageSuffix)
        {
            Galaxy galaxy = new Galaxy
            {
                Name = name,
                Type = type,
                Age = age,
                AgeSuffix = ageSuffix
            };

            this.galaxies.Add(galaxy);
        }

        public void AddStar(string starName, string galaxyName, double mass, double size, int temp, double luminosity)
        {
            Star star = new Star
            {
                Name = starName,
                Luminosity = luminosity,
                Mass = mass,
                Size = size,
                Temp = temp
            };

            Galaxy galaxy = this.galaxies.FirstOrDefault(x => x.Name == galaxyName);
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
                Name = planetName,
                Type = type,
                SupportsLife = supportsLife
            };

            Star star = this.stars.FirstOrDefault(x => x.Name == starName);

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
                Name = moonName
            };

            Planet planet = this.planets.FirstOrDefault(x => x.Name == planetName);

            if (planet != null)
            {
                planet.AddMoon(moon);
                this.moons.Add(moon);
            }
        }
    }
}
