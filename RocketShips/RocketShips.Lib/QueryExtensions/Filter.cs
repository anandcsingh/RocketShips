using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
    class Filter : IOperator
    {
        string[] words = { "the", "quick", "brown", "fox", "jumps" };

        System.Collections.ArrayList fruits;

        public Filter()
        {
            fruits = new System.Collections.ArrayList(4);
            fruits.Add("Mango");
            fruits.Add("Orange");
            fruits.Add("Apple");
            fruits.Add(3.0);
            fruits.Add("Banana");
        }

        public void Where()
        {
            var query = words.Where(w => w.Length == 3);

            foreach (string str in query)
                Console.WriteLine(str);
        }

        public void OfType()
        {
            var query = fruits.OfType<string>();

            foreach (string str in query)
                Console.WriteLine(str);
        }
    }
}
