using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib
{
    class FunctionHeaderAndWait
    {
        public void Decorate(string header, Action function)
        {
            Console.WriteLine(header);
            Console.ReadLine();

            function();

            Console.ReadLine();
        }
    }
}
