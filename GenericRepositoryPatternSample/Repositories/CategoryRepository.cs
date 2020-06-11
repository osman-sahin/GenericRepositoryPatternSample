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
    public class CategoryRepository : IRepository<Category>
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Category Add(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Category> ListAll()
        {
            return db.Categories.Include(c => c.Products).ToList();

        }
    }
}
