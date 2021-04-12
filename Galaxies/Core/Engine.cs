using Galaxies.Commands.Contracts;
using Galaxies.Core.Contracts;
using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Galaxies.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(IReader reader, ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                CommandInfo commandInfo = this.ReadCommandInfo();
                if (string.IsNullOrWhiteSpace(commandInfo.Name))
                {
                    continue;
                }

                ICommand command = this.commandInterpreter.CreateCommand(commandInfo.Name, commandInfo.Args);
                command.Execute();
            }
        }

        private CommandInfo ReadCommandInfo()
        {
            IList<string> commandArgs = this.reader.ReadLine()
                .Split(' ')
                .ToList();

            string commandName = commandArgs[0];
            commandArgs.RemoveAt(0);

            return new CommandInfo
            {
                Name = commandName,
                Args =commandArgs
            };
        }
    }
}
