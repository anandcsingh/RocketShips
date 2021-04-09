using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace RocketShips.Lib
{
    public class History
    {
        List<Product> products = new List<Product>
        {
            new Product { ID = 1, Name ="Blue Socks", Category = "Apparel"  },
            new Product { ID = 2, Name ="Blue Jeans", Category = "Apparel"  },
            new Product { ID = 3, Name ="Blue Headphones", Category = "Music"  }
        };

        public void ThenObjects()
        {
            string category = "Apparel";
            List<Product> products = new List<Product>();
            foreach (var product in products)
            {
                if (product.Category == category)
                {
                    products.Add(product);
                }
            }
        }

        public void ThenSql()
        {
            string category = "Apparel";
            string query = "SELECT ID, Name, Category from Products WHERE Category = @cat";
            string connString = "";
            List<Product> adoProducts = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cat", category);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    adoProducts.Add(new Product
                    {
                        ID = (int)reader[0],
                        Name = reader[1].ToString(),
                        Category = reader[2].ToString()
                    });
                }
                reader.Close();
                connection.Close();
            }
        }

        public void NowObjects()
        {
            string category = "Apparel";
           var foundProducts = products.Where(p => p.Category == category);
        }

        public void NowSql()
        {
            string category = "Apparel";
            ProductsContext context = new ProductsContext();
            var foundProducts = context.Products.Where(p => p.Category == category);
        }



    }
}
