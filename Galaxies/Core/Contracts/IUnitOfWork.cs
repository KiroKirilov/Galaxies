using Galaxies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Core.Contracts
{
    public interface IUnitOfWork
    {
        IEnumerable<Galaxy> Galaxies { get; }

        IEnumerable<Star> Stars { get; }

        IEnumerable<Planet> Planets { get; }

        IEnumerable<Moon> Moons { get; }

        int GalaxiesCount { get; }

        int StarsCount { get; }

        int PlanetsCount { get; }

        int MoonsCount { get; }

        void AddGalaxy(string name, string type, double age, string ageSuffix);

        void AddStar(string starName, string galaxyName, double mass, double size, int temp, double luminosity);

        void AddPlanet(string planetName, string starName, string type, bool supportsLife);

        void AddMoon(string moonName, string planetName);
    }
}
