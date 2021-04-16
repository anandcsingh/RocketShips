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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Performance");
            Console.ResetColor();
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

        public void SplitQuery()
        {
            var result = context.Customers
                .Include(pm => pm.CustomerAddresses)
                .AsSplitQuery();

            foreach (var item in result)
            {
                Console.WriteLine(item.CompanyName);
                foreach (var address in item.CustomerAddresses)
                {
                    Console.WriteLine(address.AddressType);
                }
            }
            string query = result.ToQueryString();
            System.Diagnostics.Debug.WriteLine(query);
        }



        public void ComplexQueryA()
        {
            var resultA = context.Customers
                .Include(pm => pm.CustomerAddresses)
                .Select(c => c.CustomerAddresses.Select(a => new
                {
                    c.CompanyName,
                    a.AddressType,
                    a.Address.AddressLine1
                }))
                .ToList();
        }

        public void ComplexQueryB()
        {
            var resultB = (from customer in context.Customers
                           join customerAddresses in context.CustomerAddresses on customer.CustomerId equals customerAddresses.CustomerId
                           join addresses in context.Addresses on customerAddresses.AddressId equals addresses.AddressId
                           select new
                           {
                               customer.CompanyName,
                               customerAddresses.AddressType,
                               addresses.AddressLine1
                           }).ToList();
        }



        public void PerformancePresenter()
        {
            Timer timer = new Timer();

            long smallDataSetDuration = timer.DurationFor(SimulateSmallDataSet);
            long largeDataSetDuration = timer.DurationFor(SimulateLargeDataSet);
            long complexQueryADuration = timer.DurationFor(ComplexQueryA);
            long complexQueryBDuration = timer.DurationFor(ComplexQueryB);

            Console.WriteLine($"{smallDataSetDuration.ToString().PadLeft(10, ' ')} ms: 3 customers with  addresses");
            Console.WriteLine($"{largeDataSetDuration.ToString().PadLeft(10, ' ')} ms: All customers with many addresses");
            Console.WriteLine($"{complexQueryADuration.ToString().PadLeft(10, ' ')} ms: Complex A");
            Console.WriteLine($"{complexQueryBDuration.ToString().PadLeft(10, ' ')} ms: Complex B");

        }


    }
}
