using Galaxies.Commands;
using Galaxies.Core;
using Galaxies.Core.Contracts;
using Galaxies.IO;
using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;

namespace Galaxies
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = BuildEngine();
            engine.Run();
        }

        static IEngine BuildEngine()
        {
            return new Engine(
                reader: new ConsoleReader(),
                commandInterpreter: new CommandInterpreter(
                    dependanciesDict: BuildDependenciesDict()
                    )
                );
        }

        static IDictionary<string, object> BuildDependenciesDict()
        {
            return new Dictionary<string, object>()
            {
                { typeof(IUnitOfWork).FullName, new UnitOfWork() },
                { typeof(IWriter).FullName, new ConsoleWriter() },
                { typeof(IReader).FullName, new ConsoleReader() }
            };
        }
    }
}