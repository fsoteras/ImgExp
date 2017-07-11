using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgExpnd.Commands
{
    public class NotFoundCommand : ICommand
    {
        public string Name { get; set; }
        public void Execute(string[] arg)
        {
            Console.WriteLine("Couldn't find command: " + Name);
        }
    }
}
