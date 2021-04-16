using RocketShips.Lib.Models;
using RocketShips.Lib.QueryExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib
{
    public class DeferredExecution
    {
        public DeferredExecution(AdventureWorksContext context)
        {
            this.context = context;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Deferred Execution");
            Console.ResetColor();
            Console.ReadLine();
        }

        IList<Student> studentList = new List<Student>()
        {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 25 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 34 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 22  },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 45 }
        };
        private readonly AdventureWorksContext context;

        public void DeferIEnumerable()
        {
            var students = studentList.Where(s => s.Age > 25);

            foreach (var item in students)
            {
                Console.WriteLine(item.StudentName);
            }
            Console.ReadLine();
            var second = studentList.Where(s => s.Age > 25);

            studentList.Add(new Student() { StudentID = 6, StudentName = "Bob", Age = 27 });

            foreach (var item in students)
            {
                Console.WriteLine(item.StudentName);
            }
        }

        public void DeferIQueryable()
        {
            var productsImmediate = context.Products.Where(p => p.ListPrice > 1000).Take(10).ToList();
            bool immediateAny = productsImmediate.Any(p => p.ListPrice < 2000);
            int immediateCount = productsImmediate.Count();

            var products = context.Products.Where(p => p.ListPrice > 1000).Take(10);
            bool any = products.Any(p => p.ListPrice < 2000);
            int count = products.Count();

            foreach (var item in products)
            {
                Console.WriteLine(item.Name);
            }
        }

        public void Presenter()
        {
            var runner = new FunctionHeaderAndWait();
            runner.Decorate("Defer IEnumerable", DeferIEnumerable);
            runner.Decorate("Defer IQueryable", DeferIQueryable);
        }
        //GOAB....

        // Expressions vs Actions vs Func
        // IEnumerable vs IQueryable
        // Remote Providers

        //https://www.tutorialsteacher.com/linq/linq-deferred-execution
        //https://www.tutorialsteacher.com/linq/linq-immediate-execution
    }
}
