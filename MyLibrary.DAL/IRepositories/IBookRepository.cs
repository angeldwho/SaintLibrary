﻿using MyLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL.IRepositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}