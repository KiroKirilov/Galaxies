using Galaxies.Commands.Contracts;
using Galaxies.Common;
using Galaxies.Core.Contracts;
using Galaxies.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Galaxies.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IDictionary<string, object> dependanciesDict;

        public CommandInterpreter(IDictionary<string, object> dependanciesDict)
        {
            this.dependanciesDict = dependanciesDict;
        }

        public ICommand CreateCommand(CommandInfo commandInfo)
        {
            string fullCommandName = commandInfo.Name + Constants.CommandSuffix;

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == fullCommandName.ToLower());

            if (commandType == null || !typeof(ICommand).IsAssignableFrom(commandType) || commandType.IsAbstract)
            {
                return null;
            }

            ConstructorInfo constructorInfo = commandType.GetConstructors().First();
            ParameterInfo[] constructorParametersInfo = constructorInfo.GetParameters();
            object[] parametersToInvokeWith = new object[constructorParametersInfo.Length];

            for (int i = 0; i < constructorParametersInfo.Length; i++)
            {
                Type currentParameterType = constructorParametersInfo[i].ParameterType;
                try
                {
                    if (currentParameterType == typeof(IList<string>))
                    {
                        parametersToInvokeWith[i] = commandInfo.Args;
                        continue;
                    }

                    if (this.dependanciesDict.ContainsKey(currentParameterType.FullName))
                    {
                        parametersToInvokeWith[i] = this.dependanciesDict[currentParameterType.FullName];
                    } 
                    else
                    {
                        parametersToInvokeWith[i] = null;
                    }
                }
                catch (Exception)
                {
                    parametersToInvokeWith[i] = null;
                    continue;
                }
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType, parametersToInvokeWith);

            return command;
        }
    }
}
