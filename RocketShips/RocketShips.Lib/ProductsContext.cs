using System.Collections.Generic;

namespace RocketShips.Lib
{
    internal class ProductsContext
    {
        public ProductsContext()
        {
        }

        public IEnumerable<Product> Products { get; internal set; }
    }
}