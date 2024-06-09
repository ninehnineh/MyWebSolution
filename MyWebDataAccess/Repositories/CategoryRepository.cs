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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Update(Category category)
        {
            _applicationDbContext.Categories.Update(category);
        }
    }
}
