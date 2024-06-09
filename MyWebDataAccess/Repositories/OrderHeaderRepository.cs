using BookUrBook.DataAccess.Data;
using BookUrBook.DataAccess.Repositories.IRepository;
using BookUrBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookUrBook.DataAccess.Repositories
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderHeaderRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Update(OrderHeader obj)
        {
            _applicationDbContext.OrderHeaders.Update(obj);
        }
    }
}
