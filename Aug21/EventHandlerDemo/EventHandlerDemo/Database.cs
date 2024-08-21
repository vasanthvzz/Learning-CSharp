using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerDemo
{
    internal class Database
    {
        public void SaveToDb(object sender, EventArgs e)
        {
            Console.WriteLine("Data saved to DB");
        }
    }
}
