using BookUrBook.DataAccess.Data;
using BookUrBook.DataAccess.Repositories.IRepository;
using BookUrBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUrBook.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Update(Product obj)
        {
            _applicationDbContext.Products.Update(obj);
        }
    }
}
