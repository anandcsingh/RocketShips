using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
    class Sorting : IOperator
    {
        string[] words = { "the", "quick", "brown", "fox", "jumps" };
        string[] fruits = { "grape", "passionfruit", "banana", "mango", "orange", "raspberry", "apple", "blueberry" };
        public void OrderBy()
        {
            var query = words.OrderBy(w => w.Length);

            foreach (string str in query)
                Console.WriteLine(str);
        }

        public void OrderByDescending()
        {
            var query = words.OrderByDescending(w => w.Length);

            foreach (string str in query)
                Console.WriteLine(str);
        }

        public void ThenBy()
        {
            var query = fruits.OrderBy(fruit => fruit.Length).ThenBy(fruit => fruit);

            foreach (string str in query)
                Console.WriteLine(str);
        }

        public void ThenByDescending()
        {
            var query = fruits.OrderBy(fruit => fruit.Length).ThenByDescending(fruit => fruit);

            foreach (string str in query)
                Console.WriteLine(str);
        }

        public void Reverse()
        {
            var query = fruits.Reverse();

            foreach (string str in query)
                Console.WriteLine(str);
        }
    }
}
