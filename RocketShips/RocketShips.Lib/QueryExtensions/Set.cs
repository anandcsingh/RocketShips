using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
    class Set : IOperator
    {
        string[] planets = { "Mercury", "Venus", "Venus", "Earth", "Mars", "Earth" };
        string[] planets1 = { "Mercury", "Venus", "Earth", "Jupiter" };
        string[] planets2 = { "Mercury", "Earth", "Mars", "Jupiter" };

        public void Distinct()
        {
            var query = planets.Distinct();

            foreach (string str in query)
                Console.WriteLine(str);
        }

        public void Except()
        {
            var query = planets1.Except(planets2);

            foreach (string str in query)
                Console.WriteLine(str);
        }

        public void Intersect()
        {
            var query = planets1.Intersect(planets2);

            foreach (string str in query)
                Console.WriteLine(str);
        }

        public void Union()
        {
            var query = planets1.Union(planets2);

            foreach (string str in query)
                Console.WriteLine(str);
        }
    }
}
