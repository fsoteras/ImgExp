using ImgExpnd;
using ImgExpnd.Helpers;
using System;

namespace GetImageProc
{
  

    class Program
    {
        static int Main(string[] args)
        {
            var availableCommands = PrintHelper.GetAvailableCommands();

            if (args.Length == 0)
            {
                PrintHelper.PrintUsage(availableCommands);

                return -1;

            }

            var parser = new CommandParser(availableCommands);
            var command = parser.ParseCommand(args);
            if (null != command)
            {
                command.Execute(args);
            }



            Console.ReadLine();


            return -1;
        }





    }
}


  