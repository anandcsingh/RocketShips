using RocketShips.Lib.QueryExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib.QueryExtensions
{
    partial class Projection : IOperator
    {

        public void Select()
        {
            string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };

            var query = fruits.Select((fruit, index) =>
                                  new { index, str = fruit.Substring(0, index) });

            foreach (var obj in query)
            {
                Console.WriteLine("{0}", obj);
            }
        }

        public void SelectMany()
        {
            var students = new List<Student>()
            {
                new Student(){StudentID = 1, StudentName = "James", Email = "James@j.com", Programming = new List<string>() { "C#", "Jave", "C++"} },
                new Student(){StudentID = 2, StudentName = "Sam", Email = "Sara@j.com", Programming = new List<string>() { "WCF", "SQL Server", "C#" }},
                new Student(){StudentID = 3, StudentName = "Patrik", Email = "Patrik@j.com", Programming = new List<string>() { "MVC", "Jave", "LINQ"} },
                new Student(){StudentID = 4, StudentName = "Sara", Email = "Sara@j.com", Programming = new List<string>() { "ADO.NET", "C#", "LINQ" } }
            };
            // Project the pet owner's name and the pet's name.
            var query = students.SelectMany(std => std.Programming);

            // Print the results.
            foreach (var obj in query)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
