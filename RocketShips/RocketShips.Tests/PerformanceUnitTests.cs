using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RocketShips.Lib.Models;
using System;
using Xunit;

namespace RocketShips.Tests
{
    public class PerformanceUnitTests
    {

        #region Ooooo

        AdventureWorksContext context;
        public PerformanceUnitTests()
        {
           
            var optionsBuilder = new DbContextOptionsBuilder<AdventureWorksContext>();
            optionsBuilder.UseSqlServer(connection);
            context = new AdventureWorksContext(optionsBuilder.Options);
        }
        #endregion

        [Fact]
        public void CanRunPerf()
        {
            var perf = new Lib.Performance(context);
            long init = perf.InitQuery();

            //long small = perf.SimulateSmallDataSet();
            //long large = perf.SimulateLargeDataSet();

        }
    }
}
