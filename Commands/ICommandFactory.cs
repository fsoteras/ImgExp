using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgExpnd.Commands
{
    // a Command Factory implementator should state name and description
    // and implement a factory method that spawns Commands.

    public interface ICommandFactory
    {
        string CommandName { get; }
        string CommandDescription { get; }

        ICommand MakeCommand(string[] arguments);

}
}
