using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketShips.Lib
{
    public class QueryOperators
    {
        Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>
        {


        {"sorting", new List<string> { "OrderBy", "OrderByDescending", "ThenBy", "ThenByDescending", "Reverse" } },
        {"filter", new List<string> { "Where", "OfType" } },
        {"join", new List<string> { "Join", "GroupJoin" } },
        {"equality", new List<string> { "SequenceEqual" } },
        {"concat", new List<string> { "Concat" } },
        {"group", new List<string> { "GroupBy", "ToLookup" } },
        {"generation", new List<string> { "DefaultIfEmpty", "Empty", "Range", "Repeat" } },
        {"project", new List<string> { "Select", "SelectMany" } },
        {"quantifier", new List<string> { "All", "Any", "Contains" } },
        { "set", new List<string> { "Distinct",
"Except",
"Intersect",
"Union" }},
            { "partition", new List<string> { "Skip",
"SkipWhile",
"Take",
"TakeWhile" } },
        { "element", new List<string> { "ElementAt",
"ElementAtOrDefault",
"First",
"FirstOrDefault",
"Last",
"LastOrDefault",
"Single",
"SingleOrDefault" } },
        { "conversion", new List<string> { "AsEnumerable",
"AsQueryable",
"Cast",
"OfType",
"ToArray",
"ToDictionary",
"ToList",
"ToLookup" } },
        { "aggregate", new List<string> { "Aggregate",
"Average",
"Count",
"LongCount",
"Max",
"Min",
"Sum" } } };
        public QueryOperators()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Environment.NewLine}Query operators");
            Console.ResetColor();
            Console.ReadLine();
        }

        public void Presenter()
        {
            foreach (var item in categories)
            {
                ListMethods(item.Key, item.Value);
            }

            QueryReflection reflection = new QueryReflection();
            string run = "What method do you want to run? Type C to cancel";
            Console.WriteLine(run);
            string method = Console.ReadLine();

            while (method != "c")
            {
                if (method != string.Empty)
                {
                    reflection.Actions[method]();
                }
                Console.WriteLine(run);
                method = Console.ReadLine();
            }

            Console.ReadLine();
        }

        private void ListMethods(string title, IEnumerable<string> list)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(title);
            Console.ResetColor();

            foreach (var item in list)
            {
                Console.WriteLine("    " + item);
            }
        }
       
        // Projection
        // Filter
        // Set
        // Enunuerable.Range<T>
        // SelectMany 
        // Aggregate
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/standard-query-operators-overview


        // Aggregate leaast used
        // Map Reduce Filter
        // Hadoop/
        //https://blog.submain.com/csharp-functional-programming/
        //https://codecube.net/2009/02/mapreduce-in-c-using-linq/
        //https://www.justinshield.com/2011/06/mapreduce-in-c/



    }
}
