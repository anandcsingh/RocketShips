using Microsoft.EntityFrameworkCore;
using RocketShips.Lib.Models;
using RocketShips.Lib.QueryExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RocketShips.Lib
{
    public class LanguageSupport
    {
        public LanguageSupport(AdventureWorksContext context)
        {
            this.context = context;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Language Support");
            Console.ResetColor();
            Console.ReadLine();
        }

        IList<Student> studentList = new List<Student>() 
        {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 },
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 },
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20  },
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 }
        };
        private readonly AdventureWorksContext context;

        public void LambdaExpressions()
        {
            
            Func<int, int> aTriple = x => x * 3;

            int sickBoyz = aTriple(5);
            Console.WriteLine($"Oh boy a triple 3 x 5 = {sickBoyz}");

            Func<string, string> launch = name =>
            {
                return $"{name} is launching Rocket Ships!";
            };
            string message = launch("Smoo");
            Console.WriteLine(message);

            Action action = () => Console.WriteLine("Action writes");

            Expression<Func<Student, bool>> stillTeen = s => s.Age >= 13 && s.Age <= 19;
            Console.WriteLine("Expression: {0}", stillTeen);

            Console.WriteLine("Expression Type: {0}", stillTeen.NodeType);

            var parameters = stillTeen.Parameters;

            foreach (var param in parameters)
            {
                Console.WriteLine("Parameter Name: {0}", param.Name);
                Console.WriteLine("Parameter Type: {0}", param.Type.Name);
            }
            var bodyExpr = stillTeen.Body as BinaryExpression;

            Console.WriteLine("Left side of body expression: {0}", bodyExpr.Left);
            Console.WriteLine("Binary Expression Type: {0}", bodyExpr.NodeType);
            Console.WriteLine("Right side of body expression: {0}", bodyExpr.Right);
            Console.WriteLine("Return Type: {0}", stillTeen.ReturnType);
        }

        public void IQueryableVsIEnumerable()
        {
            IEnumerable<Student> students = studentList.Where(s => s.Age >= 21).Take(10);

            IQueryable<Product> products = context.Products.Where(p => p.ListPrice > 500).Take(10);
            string query = products.ToQueryString();
            Console.WriteLine(query);
            System.Diagnostics.Debug.WriteLine(query);
        }

        public void ExtensionMethods()
        {
            string str = "<script language='javascript'>alert('got eeemm')</script>".HtmlEncode();

            Console.WriteLine(str);

            var date = 5.Minutes().Ago();
            Console.WriteLine(date);
        }

        public void VarAndTheAnonymousType()
        {
            Student a = new Student();
            var b = new Student();

            var student = new { ID = 1, FirstName = "Smoo", LastName = "Singh" };

            var students = studentList.Select(s => new { ID = s.StudentID, Name = s.StudentName });

            foreach (var s in students)
            {
                Console.WriteLine($"{s.ID} - { s.Name}");
            }
        }

        public void QuerySyntax()
        {
            var students = from s in studentList
                           where s.Age >= 20
                           select new
                           {
                               ID = s.StudentID,
                               Name = s.StudentName
                           };

            foreach (var s in students)
            {
                Console.WriteLine($"{s.ID} - { s.Name}");
            }
        }

        public void YieldAndGenerics()
        {

            Range<int> range1 = new Range<int>(23, 45);
            Range<int> range2 = new Range<int>(15, 26);
            bool overlaps = Range.Overlap(range1, range2);
            string results = overlaps ? "overlaps" : "does not overlap";

            Console.WriteLine($"{range1} {results} {range2}");

            // yield to implement deffered execution, only when you call get enumerator
            //https://www.tutorialsteacher.com/linq/linq-deferred-execution
            //Massive
            /// <summary>
            /// Enumerates the reader yielding the result - thanks to Jeroen Haegebaert
            /// </summary>
            //public virtual IEnumerable<dynamic> Query(string sql, params object[] args)
            //{
            //    using (var conn = OpenConnection())
            //    {
            //        var rdr = CreateCommand(sql, conn, args).ExecuteReader();
            //        while (rdr.Read())
            //        {
            //            yield return rdr.RecordToExpando(); ;
            //        }
            //    }
            //}
            //http://svtfs002:8080/tfs/ASG/QuikWorx/_search?text=yield&type=code&lp=dashboard-Project&filters=ProjectFilters%7BQuikWorx%7D&result=DefaultCollection%2FQuikWorx%2FQuikWorx%20API%2FGBrelease%2F1.0.0%2F%2FQuikWorx.Services.Common%2FExtensions%2FWorkflowDataContextExtensions.cs&_a=contents
            //http://svtfs002:8080/tfs/ASG/MHTL/_versionControl?path=%24%2FMHTL%2Fmhtl-mvc-beta1%2FTeleios.MhtlDss.Services%2FRange.cs
            //https://dev.azure.com/teleios-systems-qwapps/GoAB%20-%20Cabinet%20Dashboard%20Solution/_git/GoAB%20-%20Cabinet%20Dashboard%20Solution?path=%2FGoAB.Infrastructure%2FData%2FEfRepository.cs&version=GBmaster

        }

        public void Presenter()
        {
            var runner = new FunctionHeaderAndWait();
            runner.Decorate("Lambda Expressions", LambdaExpressions);
            runner.Decorate("IQueryable vs IEnumerable", IQueryableVsIEnumerable); 
            runner.Decorate("Extension Methods", ExtensionMethods);
            runner.Decorate("Var and the Anonymous Type", VarAndTheAnonymousType);
            runner.Decorate("Query Syntax", QuerySyntax);
            runner.Decorate("Yield and Generics", YieldAndGenerics);
        }
    }

    public static class StringExtensions
    {
        public static string HtmlEncode(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
    }

    public static class TimeSpanExtensions
    {
        public static TimeSpan Minutes(this int value)
        {
            return new TimeSpan(0, 0, value, 0, 0);
        }

        public static TimeSpan Days(this int value)
        {
            return new TimeSpan(value, 0, 0, 0);
        }

        public static DateTime Ago(this TimeSpan value)
        {
            return DateTime.Now - value;
        }
    }
}
