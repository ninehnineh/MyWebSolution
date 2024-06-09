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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ShoppingCartRepository(ApplicationDbContext applicationDbContext) 
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Update(ShoppingCart obj)
        {
            _applicationDbContext.ShoppingCarts.Update(obj);
        }
    }
}
