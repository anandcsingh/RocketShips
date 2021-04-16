using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
    class Element : IOperator
    {
        public void ElementAt()
        {
            string[] names = { "Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu" };
            Random random = new Random(DateTime.Now.Millisecond);

            string name = names.ElementAt(random.Next(0, names.Length));

            Console.WriteLine("The name chosen at random is '{0}'.", name);
        }

        public void ElementAtOrDefault()
        {
            string[] names = { "Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", "Hedlund, Magnus", "Ito, Shu" };

            int index = 20;

            string name = names.ElementAtOrDefault(index);

            Console.WriteLine("The name chosen at index {0} is '{1}'.", index, String.IsNullOrEmpty(name) ? "<no name at this index>" : name);
        }
        public void First()
        {
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54,
                    83, 23, 87, 435, 67, 12, 19 };

            int first = numbers.First(number => number > 80);

            Console.WriteLine(first);
        }

        public void FirstOrDefault()
        {
            string[] names = { "Hartono, Tommy", "Adams, Terry",
                     "Andersen, Henriette Thaulow",
                     "Hedlund, Magnus", "Ito, Shu" };

            string firstLongName = names.FirstOrDefault(name => name.Length > 20);

            Console.WriteLine("The first long name is '{0}'.", firstLongName);
        }

        public void Last()
        {
            int[] numbers = { 9, 34, 65, 92, 87, 435, 3, 54,
                    83, 23, 87, 67, 12, 19 };

            int last = numbers.Last();

            Console.WriteLine(last);
        }

        public void LastOrDefault()
        {
            double[] numbers = { 49.6, 52.3, 51.0, 49.4, 50.2, 48.3 };

            double last50 = numbers.LastOrDefault(n => Math.Round(n) == 50.0);

            Console.WriteLine("The last number that rounds to 50 is {0}.", last50);

            double last40 = numbers.LastOrDefault(n => Math.Round(n) == 40.0);

            Console.WriteLine(
                "The last number that rounds to 40 is {0}.",
                last40 == 0.0 ? "<DOES NOT EXIST>" : last40.ToString());

        }

        public void Single()
        {
            string[] fruits = { "apple", "banana", "mango",
                      "orange", "passionfruit", "grape" };

            string fruit1 = fruits.Single(fruit => fruit.Length > 10);

            Console.WriteLine(fruit1);
        }

        public void SingleOrDefault()
        {
            string[] fruits = { "apple", "banana", "mango",
                      "orange", "passionfruit", "grape" };

            string fruit1 = fruits.SingleOrDefault(fruit => fruit.Length > 10);

            Console.WriteLine(fruit1);
        }
    }


}
