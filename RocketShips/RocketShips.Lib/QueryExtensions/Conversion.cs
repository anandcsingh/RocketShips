using RocketShips.Lib.QueryExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{

    class Conversion : IOperator
    {

        public void AsEnumerable()
        {
            int[] numarray = new int[] { 1, 2, 3, 4 };

            var result = numarray.AsEnumerable();

            foreach (var number in result)

            {
                Console.WriteLine(number);

            }
        }

        public void AsQueryable()
        {
            List<int> grades = new List<int> { 78, 92, 100, 37, 81 };

            // Convert the List to an IQueryable<int>.
            IQueryable<int> iqueryable = grades.AsQueryable();

            // Get the Expression property of the IQueryable object.
            System.Linq.Expressions.Expression expressionTree =
                iqueryable.Expression;

            Console.WriteLine("The NodeType of the expression tree is: "
                + expressionTree.NodeType.ToString());
            Console.WriteLine("The Type of the expression tree is: "
                + expressionTree.Type.Name);
        }

        public void Cast()
        {
            System.Collections.ArrayList fruits = new System.Collections.ArrayList();
            fruits.Add("mango");
            fruits.Add("apple");
            fruits.Add("lemon");

            IEnumerable<string> query =
                fruits.Cast<string>().OrderBy(fruit => fruit).Select(fruit => fruit);

            // The following code, without the cast, doesn't compile.
            //IEnumerable<string> query1 =
            //    fruits.OrderBy(fruit => fruit).Select(fruit => fruit);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }
        }

        public void ToArray()
        {
            List<Package> packages =
         new List<Package>
             { new Package { Company = "Coho Vineyard", Weight = 25.2 },
              new Package { Company = "Lucerne Publishing", Weight = 18.7 },
              new Package { Company = "Wingtip Toys", Weight = 6.0 },
              new Package { Company = "Adventure Works", Weight = 33.8 } };

            string[] companies = packages.Select(pkg => pkg.Company).ToArray();

            foreach (string company in companies)
            {
                Console.WriteLine(company);
            }
        }

        public void ToDictionary()
        {
            List<Package> packages =
        new List<Package>
            { new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
              new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
              new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
              new Package { Company = "Adventure Works", Weight = 33.8, TrackingNumber = 4665518773L } };

            // Create a Dictionary of Package objects,
            // using TrackingNumber as the key.
            Dictionary<long, Package> dictionary =
                packages.ToDictionary(p => p.TrackingNumber);

            foreach (KeyValuePair<long, Package> kvp in dictionary)
            {
                Console.WriteLine(
                    "Key {0}: {1}, {2} pounds",
                    kvp.Key,
                    kvp.Value.Company,
                    kvp.Value.Weight);
            }
        }

        public void ToList()
        {
            string[] fruits = { "apple", "passionfruit", "banana", "mango",
                      "orange", "blueberry", "grape", "strawberry" };

            List<int> lengths = fruits.Select(fruit => fruit.Length).ToList();

            foreach (int length in lengths)
            {
                Console.WriteLine(length);

            }
        }

    }
}
