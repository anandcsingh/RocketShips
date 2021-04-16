using RocketShips.Lib.QueryExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
    partial class Aggregation : IOperator
    {

        public void Aggregate()
        {
            string[] skills = { "C#.NET", "MVC", "WCF", "SQL", "LINQ", "ASP.NET" };
            string result = skills.Aggregate((s1, s2) => s1 + ", " + s2);

            Console.WriteLine(result);
        }

        public void Average()
        {
            string[] numbers = { "10007", "37", "299" };

            double average = numbers.Average(num => int.Parse(num));

            Console.WriteLine("The average is {0}.", average);
        }

        public void Count()
        {
            Pet[] pets = { new Pet { Name="Barley", Vaccinated=true },
                   new Pet { Name="Boots", Vaccinated=false },
                   new Pet { Name="Whiskers", Vaccinated=false } };

            int numberUnvaccinated = pets.Count(p => !p.Vaccinated);
            Console.WriteLine("There are {0} unvaccinated animals.", numberUnvaccinated);

        }

        public void LongCount()
        {
            string[] fruits = { "apple", "banana", "mango",
                      "orange", "passionfruit", "grape" };

            long count = fruits.LongCount();

            Console.WriteLine("There are {0} fruits in the collection.", count);

        }

        public void Max()
        {
            double?[] doubles = { null, 1.5E+104, 9E+103, -2E+103 };

            double? max = doubles.Max();

            Console.WriteLine("The largest number is {0}.", max);

        }

        public void Min()
        {
            double[] doubles = { 1.5E+104, 9E+103, -2E+103 };

            double min = doubles.Min();

            Console.WriteLine("The smallest number is {0}.", min);

        }

        public void Sum()
        {
            List<float> numbers = new List<float> { 43.68F, 1.25F, 583.7F, 6.5F };

            float sum = numbers.Sum();

            Console.WriteLine("The sum of the numbers is {0}.", sum);

        }
    }
}
