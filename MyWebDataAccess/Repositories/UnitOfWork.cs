using BookUrBook.DataAccess.Data;
using BookUrBook.DataAccess.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUrBook.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationDbContext;
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }

        public IShoppingCartRepository ShoppingCartRepository { get; private set; }

        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public IOrderHeaderRepository OrderHeaderRepository { get; private set; }

        public IOrderDetailRepository OrderDetailRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            ApplicationUserRepository = new ApplicationUserRepository(_applicationDbContext);
            ShoppingCartRepository = new ShoppingCartRepository(_applicationDbContext);
            CategoryRepository = new CategoryRepository(_applicationDbContext);
            ProductRepository = new ProductRepository(_applicationDbContext);
            CompanyRepository = new CompanyRepository(_applicationDbContext);
            OrderHeaderRepository = new OrderHeaderRepository(_applicationDbContext);
            OrderDetailRepository = new OrderDetailRepository(_applicationDbContext);
        }


        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
