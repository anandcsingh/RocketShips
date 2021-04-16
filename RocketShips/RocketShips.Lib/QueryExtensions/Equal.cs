using RocketShips.Lib.QueryExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
    class Equal : IOperator
    {

        public void SequenceEqual()
        {
            Pet pet1 = new Pet { Name = "Turbo", Age = 2 };
            Pet pet2 = new Pet { Name = "Peanut", Age = 8 };

            // Create two lists of pets.
            List<Pet> pets1 = new List<Pet> { pet1, pet2 };
            List<Pet> pets2 = new List<Pet> { pet1, pet2 };

            bool equal = pets1.SequenceEqual(pets2);

            Console.WriteLine(
                "The lists {0} equal.",
                equal ? "are" : "are not");
        }

    }
}
