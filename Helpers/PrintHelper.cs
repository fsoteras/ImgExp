using ImgExpnd.Commands;
using System;
using System.Collections.Generic;

namespace ImgExpnd.Helpers
{
    public static class PrintHelper
    {
        public static void PrintUsage(IEnumerable<ICommandFactory> availableCommands)
        {
            Console.WriteLine("Usage: ImgExpnCommandName Arguments");
            Console.WriteLine("Commands:");
            foreach (var command in availableCommands)
                Console.WriteLine("  {0}", command.CommandDescription);
        }

        public static IEnumerable<ICommandFactory> GetAvailableCommands()
        {
            return new ICommandFactory[]
            {
            new ResizeByPercentageCommand(),
            new DoubleSizeCommand()
            };
        }
    }
}
