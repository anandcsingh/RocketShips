using RocketShips.Lib;
using RocketShips.Lib.Models;
using System;
using System.Linq;
using System.Threading;

namespace RocketShips.Move
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventureWorksContext context = new AdventureWorksContext();
            //new IntroAnimation().Play();


            //History history = new History(context);
            //history.HistoryPresenter();
            QueryOperators queryOperators = new QueryOperators();
            queryOperators.Presenter();

            //Performance perf = new Performance(context);
            //perf.PerformancePresenter();

            Console.ReadLine();
        }

       
    }
}
