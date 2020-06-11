using GenericRepositoryPatternSample.Interfaces;
using GenericRepositoryPatternSample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPatternSample.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Product Add(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Product> ListAll()
        {
            return db.Products.Include(c => c.Category).ToList();
        }
    }
}
