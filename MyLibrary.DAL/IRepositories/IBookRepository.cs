using MyLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL.IRepositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<int?> GetAuthorIdBySurnameAsync(string lastname);

        Task<IList<int>> GetCategoryIdsByNamesAsync(IList<string> names);
        Task<Dictionary<int, string>> GetAuthorSurnamesAsync();
        Task<Dictionary<int, string>> GetCategoryNamesAsync();
    }
}
