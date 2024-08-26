using MyLibrary.DAL.Entities;
using MyLibrary.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
    }
}
