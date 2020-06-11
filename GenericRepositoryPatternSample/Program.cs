using GenericRepositoryPatternSample.Models;
using GenericRepositoryPatternSample.Repositories;
using System;

namespace GenericRepositoryPatternSample
{
    class Program
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        static void Main(string[] args)
        {
            // veritabanı yoksa olusturuldugundan emin olmak icin. varsa bi sey yapmaz
            db.Database.EnsureCreated();

            Console.WriteLine("Products:");

            using (var productRepository = new ProductRepository())
            {
                productRepository.Add(new Product { ProductName = "Mouse", CategoryId = 2 });

                foreach (var product in productRepository.ListAll())
                {
                    Console.WriteLine("* {0} ({1})", product.ProductName, product.Category.CategoryName);
                }
                Console.WriteLine("");
                Console.WriteLine("---------------");
                Console.WriteLine("");
            }

            using (var categoryRepository = new CategoryRepository())
            {
                foreach (var category in categoryRepository.ListAll())
                {
                    Console.WriteLine("* {0} (Ürün Adedi: {1})", category.CategoryName, category.Products.Count);
                }
            }

            Console.ReadKey();
        }
    }
}
