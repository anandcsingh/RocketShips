using RocketShips.Lib.QueryExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
   

    class Quantifier : IOperator
    {
       

        Pet[] pets;
        public Quantifier()
        {
            pets = new Pet[] { new Pet { Name="Barley", Age=10 },
                   new Pet { Name="Boots", Age=4 },
                   new Pet { Name="Whiskers", Age=6 } };
        }

        public void All()
        {
            var allStartWithB = pets.All(pet => pet.Name.StartsWith("B"));

            Console.WriteLine("{0} pet names start with 'B'.", allStartWithB ? "All" : "Not all");
        }

        public void Any()
        {
            List<int> numbers = new List<int> { 1, 2 };
            bool hasElements = numbers.Any();

            Console.WriteLine("The list {0} empty.", hasElements ? "is not" : "is");
        }

        public void Contains()
        {
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };
            string fruit = "mango";

            bool hasMango = fruits.Contains(fruit);

            Console.WriteLine("The array {0} contain '{1}'.", hasMango ? "does" : "does not", fruit);
        }
    }
}
