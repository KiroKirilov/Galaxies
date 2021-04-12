using Galaxies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies.Core.Contracts
{
    public interface IUnitOfWork
    {
        IEnumerable<Galaxy> Galaxies { get; }

        void AddGalaxy(string name, string type, string ageString);
    }
}
