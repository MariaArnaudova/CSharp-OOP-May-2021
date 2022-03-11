using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    using Commands;
    using Contracts;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArguments = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = (inputArguments[0] + "Command").ToLower();
            string[] commandArgs = inputArguments.Skip(1).ToArray();

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == commandName);

            if (commandType ==null)
            {
                throw new ArgumentException("Invalid command type");
            }

            ICommand instanceType = Activator.CreateInstance(commandType) as ICommand;

            if (instanceType == null)
            {
                throw new ArgumentException("Invalid command type");
            }

            string result = instanceType.Execute(commandArgs);
            return result;
        }
    }
}
