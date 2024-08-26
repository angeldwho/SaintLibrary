using MyLibrary.DAL.Data;
using MyLibrary.DAL.Entities;
using MyLibrary.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(LibraryContext context) : base(context)
        {
            
        }
    }
}
