using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Command pattern
// Encapsulate a request as an object, thereby letting you parameterize clients
// with different requests, queue or log requests, and support undoable operations.

namespace ImgExpnd
{
    public interface ICommand
    {
       void Execute(string[] args);
    }
}
