using RocketShips.Lib.QueryExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/generation-operations
    class Generate : IOperator
    {

        public void DefaultIfEmpty()
        {
            Pet defaultPet = new Pet { Name = "Default Pet", Age = 0 };

            List<Pet> pets1 =
                new List<Pet>{ new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 } };

            foreach (Pet pet in pets1.DefaultIfEmpty(defaultPet))
            {
                Console.WriteLine("Name: {0}", pet.Name);
            }

            List<Pet> pets2 = new List<Pet>();

            foreach (Pet pet in pets2.DefaultIfEmpty(defaultPet))
            {
                Console.WriteLine("\nName: {0}", pet.Name);
            }
        }

        public void Empty()
        {
            string[] names1 = { "Hartono, Tommy" };
            string[] names2 = { "Adams, Terry", "Andersen, Henriette Thaulow",
                      "Hedlund, Magnus", "Ito, Shu" };
            string[] names3 = { "Solanki, Ajay", "Hoeing, Helge",
                      "Andersen, Henriette Thaulow",
                      "Potra, Cristina", "Iallo, Lucio" };

            List<string[]> namesList =
                new List<string[]> { names1, names2, names3 };

            // Only include arrays that have four or more elements
            IEnumerable<string> allNames =
                namesList.Aggregate(Enumerable.Empty<string>(),
                (current, next) => next.Length > 3 ? current.Union(next) : current);

            foreach (string name in allNames)
            {
                Console.WriteLine(name);
            }
        }

        public void Range()
        {
            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

            foreach (int num in squares)
            {
                Console.WriteLine(num);
            }
        }

        public void Repeat()
        {
            IEnumerable<string> strings = Enumerable.Repeat("I like programming.", 15);

            foreach (String str in strings)
            {
                Console.WriteLine(str);
            }
        }
    }
}
