﻿using BookUrBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUrBook.DataAccess.Repositories.IRepository
{
    public interface ICompanyRepository : IRepository<Companies>
    {
        void Update(Companies obj);

    }
}
