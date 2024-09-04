using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.IServices
{
    public interface IBookService : IGenericService<BookCreateRequestModel,BookRequestModel,Book>
    {
        Task<int?> GetAuthorIdBySurnameAsync(string surname);
        Task<IList<int>> GetCategoryIdsByNamesAsync(IList<string> names);
        Task<Dictionary<int, string>> GetAuthorSurnamesAsync();
        Task<Dictionary<int, string>> GetCategoryNamesAsync();
        Task CreateBook(BookCreateRequestModel requestModel);
        Task<BookRequestModel> UpdateBook(BookRequestModel requestModel);
    }
}
