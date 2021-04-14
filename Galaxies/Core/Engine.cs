using Galaxies.Commands;
using Galaxies.Commands.Contracts;
using Galaxies.Core.Contracts;
using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            // the app is closed with the exit command
            while (true)
            {
                CommandInfo commandInfo = this.ReadCommandInfo();
                if (string.IsNullOrWhiteSpace(commandInfo.Name))
                {
                    continue;
                }

                ICommand command = this.commandInterpreter.CreateCommand(commandInfo);
                command.Execute();
            }
        }

        private CommandInfo ReadCommandInfo()
        {
            string commandLine = this.reader.ReadLine();

            // split by space, unless it's in brackets
            IList<string> commandArgs = Regex.Split(commandLine, @"\s+(?![^\\[]*\])").ToList();

            string commandName = commandArgs[0];
            commandArgs.RemoveAt(0);

            return new CommandInfo
            {
                Name = commandName,
                Args = commandArgs
            };
        }
    }
}
