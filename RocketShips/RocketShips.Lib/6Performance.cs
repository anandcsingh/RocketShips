using RocketShips.Lib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RocketShips.Lib
{
    public class Performance
    {
        private readonly AdventureWorksContext context;

        // simulate small dataset by taking a take before the ToList
        //small data set
        // large data set
        // time ToList vs deferred (where)
        // insidious when the ata is small you dont see the problem
        // problem queries -> 
        // Measure first when it comes to performance
        // My personal opinion is this approach is not nuanced
        // I can the page is taking long to load, do I need instrumentation to tell me this?
        // I have experience should I not consider it in my building 

        // Do we want to wait until we must build highly performant code to learn how
        // practice while the stakes are low easy way to learn

        public Performance(AdventureWorksContext context)
        {
            this.context = context;
            InitQuery();
            Console.WriteLine("Performance");
            Console.ReadLine();
        }

        public void InitQuery()
        {
            var result = context.Products.Take(1).ToList();
        }

        public void SimulateSmallDataSet()
        {
            var result = context.Customers
                .Include(pm => pm.CustomerAddresses)
                .Take(3);
            string query = result.ToQueryString();
            var output = result.ToList();

            System.Diagnostics.Debug.WriteLine(query);
        }

        public void SimulateLargeDataSet()
        {
            var result = context.Customers
                .Include(pm => pm.CustomerAddresses);
            string query = result.ToQueryString();
            var output = result.ToList();

            System.Diagnostics.Debug.WriteLine(query);
        }

        public void PerformancePresenter()
        {
            Timer timer = new Timer();

            long smallDataSetDuration = timer.DurationFor(SimulateSmallDataSet);
            long largeDataSetDuration = timer.DurationFor(SimulateLargeDataSet);

            Console.WriteLine($"{smallDataSetDuration.ToString().PadLeft(10, ' ')} ms: 3 customers with  addresses");
            Console.WriteLine($"{largeDataSetDuration.ToString().PadLeft(10, ' ')} ms: All customers with many addresses");

        }


    }
}
