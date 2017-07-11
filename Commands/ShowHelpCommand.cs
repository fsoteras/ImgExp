using ImgExpnd.Helpers;

namespace ImgExpnd.Commands
{
    class ShowHelpCommand : ICommand
    {
        public void Execute(string[] args)
        {

            var availableCommands = PrintHelper.GetAvailableCommands();

            if (args.Length == 0)
            {
                PrintHelper.PrintUsage(availableCommands);

                //  return -1;
            }
        }

    }

}





