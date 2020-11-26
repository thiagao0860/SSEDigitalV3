using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SSEDigitalV3.GlobalTools
{
    class InputError : Exception
    {
        public Control target;
        public string appMessage;
        public InputError(string message,Control target)
        {
            this.appMessage = message;
            this.target = target;
        }
    }
}
