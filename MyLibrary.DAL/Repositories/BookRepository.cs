using Microsoft.EntityFrameworkCore;
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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LibraryContext _libraryContext;
        public BookRepository(LibraryContext context) : base(context) 
        {
            _libraryContext = context;
        }
        public async Task<int?> GetAuthorIdBySurnameAsync(string lastname)
        {
            var author = await _libraryContext.Set<Author>().FirstOrDefaultAsync(a => a.LastName == lastname);
            return author?.ID;
        }

        public async Task<IList<int>> GetCategoryIdsByNamesAsync(IList<string> names)
        {
            return await _libraryContext.Set<Category>()
                                 .Where(c => names.Contains(c.Name))
                                 .Select(c => c.ID)
                                 .ToListAsync();
        }
        public async Task<Dictionary<int, string>> GetAuthorSurnamesAsync()
        {
            return await _libraryContext.Set<Author>().ToDictionaryAsync(a => a.ID, a => a.LastName);
        }

        public async Task<Dictionary<int, string>> GetCategoryNamesAsync()
        {
            return await _libraryContext.Set<Category>().ToDictionaryAsync(c => c.ID, c => c.Name);
        }
    }
}
