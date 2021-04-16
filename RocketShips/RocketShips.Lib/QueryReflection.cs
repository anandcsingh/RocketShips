using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RocketShips.Lib.QueryExtensions;
namespace RocketShips.Lib
{
    public class QueryReflection
    {
        public QueryReflection()
        {
            ManualWithNimbleText();
            //ReflectionLaziness();
        }

        //private void ReflectionLaziness()
        //{
        //    Actions = new Dictionary<string, Action>(); 
        //    var operators = Assembly.GetExecutingAssembly().GetTypes()
        //        .Where(t => t.IsClass && t.GetInterface("IOperator") != null);
            
        //    foreach (var item in operators)
        //    {
        //        object obj = Activator.CreateInstance(item);
                
        //        var methods = item.GetMethods();
        //        foreach (var method in methods)
        //        {
        //            method.
        //            Actions.Add(method.Name, )
        //        }
        //    }
        //}

        private void ManualWithNimbleText()
        {
            Aggregation Aggregation = new Aggregation();
            Concatenation Concatenation = new Concatenation();
            Conversion Conversion = new Conversion();
            Element Element = new Element();
            Equal Equal = new Equal();
            Filter Filter = new Filter();
            Generate Generate = new Generate();
            Group Group = new Group();
            JoinOperation JoinOperation = new JoinOperation();
            Partition Partition = new Partition();
            Projection Projection = new Projection();
            Quantifier Quantifier = new Quantifier();
            Set Set = new Set();
            Sorting Sorting = new Sorting();

            Actions = new Dictionary<string, Action>();

            Actions.Add("OrderBy", Sorting.OrderBy);
            Actions.Add("OrderByDescending", Sorting.OrderByDescending);
            Actions.Add("ThenBy", Sorting.ThenBy);
            Actions.Add("ThenByDescending", Sorting.ThenByDescending);
            Actions.Add("Reverse", Sorting.Reverse);
            Actions.Add("Where", Filter.Where);
            Actions.Add("OfType", Filter.OfType);
            Actions.Add("Join", JoinOperation.Join);
            Actions.Add("GroupJoin", JoinOperation.GroupJoin);
            Actions.Add("SequenceEqual", Equal.SequenceEqual);
            Actions.Add("Concat", Concatenation.Concat);
            Actions.Add("GroupBy", Group.GroupBy);
            Actions.Add("ToLookup", Group.ToLookup);
            Actions.Add("DefaultIfEmpty", Generate.DefaultIfEmpty);
            Actions.Add("Empty", Generate.Empty);
            Actions.Add("Range", Generate.Range);
            Actions.Add("Repeat", Generate.Repeat);
            Actions.Add("Select", Projection.Select);
            Actions.Add("SelectMany", Projection.SelectMany);
            Actions.Add("All", Quantifier.All);
            Actions.Add("Any", Quantifier.Any);
            Actions.Add("Contains", Quantifier.Contains);
            Actions.Add("Distinct", Set.Distinct);
            Actions.Add("Except", Set.Except);
            Actions.Add("Intersect", Set.Intersect);
            Actions.Add("Union", Set.Union);
            Actions.Add("Skip", Partition.Skip);
            Actions.Add("SkipWhile", Partition.SkipWhile);
            Actions.Add("Take", Partition.Take);
            Actions.Add("TakeWhile", Partition.TakeWhile);
            Actions.Add("ElementAt", Element.ElementAt);
            Actions.Add("ElementAtOrDefault", Element.ElementAtOrDefault);
            Actions.Add("First", Element.First);
            Actions.Add("FirstOrDefault", Element.FirstOrDefault);
            Actions.Add("Last", Element.Last);
            Actions.Add("LastOrDefault", Element.LastOrDefault);
            Actions.Add("Single", Element.Single);
            Actions.Add("SingleOrDefault", Element.SingleOrDefault);
            Actions.Add("AsEnumerable", Conversion.AsEnumerable);
            Actions.Add("AsQueryable", Conversion.AsQueryable);
            Actions.Add("Cast", Conversion.Cast);
            Actions.Add("ToArray", Conversion.ToArray);
            Actions.Add("ToDictionary", Conversion.ToDictionary);
            Actions.Add("ToList", Conversion.ToList);
            Actions.Add("Aggregate", Aggregation.Aggregate);
            Actions.Add("Average", Aggregation.Average);
            Actions.Add("Count", Aggregation.Count);
            Actions.Add("LongCount", Aggregation.LongCount);
            Actions.Add("Max", Aggregation.Max);
            Actions.Add("Min", Aggregation.Min);
            Actions.Add("Sum", Aggregation.Sum);
        }

        public Dictionary<string, Action> Actions { get; set; }


    }
}
