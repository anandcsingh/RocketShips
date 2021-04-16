using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            var optionsBuilder = new DbContextOptionsBuilder<AdventureWorksContext>();
            optionsBuilder.UseSqlServer(Settings.Adventure);
            AdventureWorksContext context = new AdventureWorksContext(optionsBuilder.Options);
            new IntroAnimation().Play();
            
            History history = new History(context);
            history.Presenter();

            LanguageSupport language = new LanguageSupport(context);
            language.Presenter();

            QueryOperators queryOperators = new QueryOperators();
            queryOperators.Presenter();

            DeferredExecution deferred = new DeferredExecution(context);
            deferred.Presenter();
            
            Performance perf = new Performance(context);
            perf.PerformancePresenter();

            Console.ReadLine();
        }

       
    }
}
