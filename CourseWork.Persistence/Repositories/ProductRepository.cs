using CourseWork.Domain.Models;
using CourseWork.Domain.Repositories;
using CourseWork.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        { 
            this.appDbContext = appDbContext;
        }
        public void Create(Product product)
        {
            this.appDbContext.Products.Add(product);
            this.appDbContext.SaveChanges();
        }
        public void Update(Product product)
        {
            this.appDbContext.Products.Update(product);
            this.appDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = this.appDbContext.Products.Find(id);
            this.appDbContext.Products.Remove(product);
            this.appDbContext.SaveChanges();
        }
    }
}
