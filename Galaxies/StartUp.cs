using Galaxies.Commands;
using Galaxies.Core;
using Galaxies.Core.Contracts;
using Galaxies.IO;
using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Galaxies
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            IEngine engine = BuildEngine();
            engine.Run();
        }

        static IEngine BuildEngine()
        {
            IDictionary<string, object> dependanciesDict = BuildDependenciesDict();

            return new Engine(
                reader: dependanciesDict[typeof(IReader).FullName] as IReader,
                commandInterpreter: new CommandInterpreter(
                    dependanciesDict: dependanciesDict
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