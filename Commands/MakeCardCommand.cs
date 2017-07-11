using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor.Imaging.Formats;
using System.Drawing.Imaging;

namespace ImgExpnd.Commands
{
    public class MakeCardCommand : ICommand, ICommandFactory
    {
        public string CommandDescription
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string CommandName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Execute(string[] args)
        {
            throw new NotImplementedException();
        }

        public ICommand MakeCommand(string[] arguments)
        {
            throw new NotImplementedException();
        }
    }
}
