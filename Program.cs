using ImgExpnd;
using ImgExpnd.Helpers;
using System;

namespace GetImageProc
{
    // version alpha 0.9.3 , first rough version , testing how to call ImageProcessor lib.
    // This code assume to-be-processed pics to be found on  /pictures folder.

    // version alpha 0.9.4 , implementation of Command pattern , all new functionality
    // will be implemented with classes implementing ICommand interface.

    //  version alpha 0.9.5 , first releaseable version.

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


  