using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerDemo
{
    class IDCardGenerator
    {
        public void GenerateCard(object sender, UserArgs e)
        {
            Console.WriteLine("ID card generated for user "+e.Name);
        }
    }
}
