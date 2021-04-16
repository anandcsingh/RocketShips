using Microsoft.EntityFrameworkCore;
using RocketShips.Lib.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace RocketShips.Lib
{
    public class History
    {
        string connString;

        public History(AdventureWorksContext context)
        {
            this.context = context;
            connString = context.Database.GetDbConnection().ConnectionString;
            Console.WriteLine("History");
            Console.ReadLine();
        }

        List<Product> products = new List<Product>
        {
            new Product { ID = 1, Name ="Blue Socks", Category = "Apparel"  },
            new Product { ID = 2, Name ="Blue Jeans", Category = "Apparel"  },
            new Product { ID = 3, Name ="Blue Headphones", Category = "Music"  }
        };
        private readonly AdventureWorksContext context;

        public HistoryModel ThenObjects()
        {
            string category = "Apparel";
            List<Product> foundProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.Category == category)
                {
                    foundProducts.Add(product);
                }
            }

            string productStr = string.Empty;
            int length = foundProducts.Count;
            Product item;
            for (int i = 0; i < length; i++)
            {
                item = foundProducts[i];
                if (i == length - 1)
                {
                    productStr += item.Name;
                }
                else
                {
                    productStr += item.Name + ", ";
                }
            }
            HistoryModel model = new HistoryModel();
            model.Count = foundProducts.Count;
            model.FoundProducts = productStr;

            return model;
        }

        public HistoryModel ThenSql()
        {
            int categoryID = 10;
            string query = @"SELECT p.ProductID, p.Name, pc.Name AS Category
FROM [SalesLT].[Product] p
INNER JOIN[SalesLT].[ProductCategory] pc ON p.ProductCategoryID = pc.ProductCategoryID
WHERE p.ProductCategoryID = " + categoryID;
            
            List<Product> adoProducts = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(query, connection);
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

            string productStr = string.Empty;
            int length = adoProducts.Count;
            Product item;
            for (int i = 0; i < length; i++)
            {
                item = adoProducts[i];
                if (i == length - 1)
                {
                    productStr += item.Name;
                }
                else
                {
                    productStr += item.Name + ", ";
                }
            }
            HistoryModel model = new HistoryModel();
            model.Count = adoProducts.Count;
            model.FoundProducts = productStr;
            return model;
        }

        public HistoryModel NowObjects()
        {
            string category = "Apparel";
            var foundProducts = products
                .Where(p => p.Category == category)
                .Select(p => p.Name);

            return new HistoryModel
            {
                Count = foundProducts.Count(),
                FoundProducts = string.Join(", ", foundProducts)
            };
        }

        public HistoryModel NowSql()
        {
            string category = "Brakes";
            var foundProducts = context.Products
                .Where(p => p.ProductCategory.Name == category)
                .Select(p => p.Name);

            return new HistoryModel
            {
                Count = foundProducts.Count(),
                FoundProducts = string.Join(", ", foundProducts)
            };
        }


        #region

        public class HistoryModel
        {
            public int Count { get; set; }
            public string FoundProducts { get; set; }
        }
        class Product
        {
            public int ID { get; internal set; }
            public string Name { get; internal set; }
            public string Category { get; internal set; }
        }

        public void HistoryPresenter()
        {
            var thenObj = ThenObjects();
            Write("Then", thenObj.Count, thenObj.FoundProducts);
            var nowObj = NowObjects();
            Write("Now", nowObj.Count, nowObj.FoundProducts);
            var thenSql = ThenSql();
            Write("Then SQL", thenSql.Count, thenSql.FoundProducts);
            var nowSql = NowSql();
            Write("Now SQL", thenSql.Count, thenSql.FoundProducts);
        }

        public void Write(string state, int count, string found)
        {
            Console.WriteLine($"{state} found {count}: {found}");
        }


        
        #endregion
    }
}
