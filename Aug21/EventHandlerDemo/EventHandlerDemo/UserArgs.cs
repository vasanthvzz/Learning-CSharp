using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerDemo
{
    public class UserArgs : EventArgs
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
