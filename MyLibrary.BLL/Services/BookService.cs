using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.DAL.Entities;
using MyLibrary.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.Services
{
    public class BookService : GenericService<BookCreateRequestModel,BookRequestModel,Book>, IBookService

    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        public BookService(IMapper mapper,IGenericRepository<Book> genericBookRepository, IBookRepository bookRepository, IAuthorService authorService, ICategoryService categoryService) : base(mapper,genericBookRepository)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
        }
        public async Task<int?> GetAuthorIdBySurnameAsync(string surname)
        {
            return await _bookRepository.GetAuthorIdBySurnameAsync(surname);
        }

        public async Task<IList<int>> GetCategoryIdsByNamesAsync(IList<string> names)
        {
            return await _bookRepository.GetCategoryIdsByNamesAsync(names);
        }
        public async Task<Dictionary<int, string>> GetAuthorSurnamesAsync()
        {
            return await _bookRepository.GetAuthorSurnamesAsync();
        }

        public async Task<Dictionary<int, string>> GetCategoryNamesAsync()
        {
            return await _bookRepository.GetCategoryNamesAsync();
        }
        public async Task CreateBook(BookCreateRequestModel requestModel)
        {
            var authorId = await GetAuthorIdBySurnameAsync(requestModel.AuthorSurname);
            if (authorId == null)
            {
                Console.WriteLine("Author not found");
            }
            var categoryIds = await GetCategoryIdsByNamesAsync(requestModel.CategoryNames);
            var author = await _authorService.Find(authorId.Value);
            var book = new BookCreateRequestModel
            {
                Title = requestModel.Title,
                Description = requestModel.Description,
                AuthorId = author.ID,
                CategoryIds = categoryIds,
            };
            await Create(book);
            Console.WriteLine("Book created?");
        }
        public async Task<BookRequestModel> UpdateBook(BookRequestModel requestModel)
        {
            try
            {
                var foundElement = await Find(requestModel.ID);
                if (foundElement is not null)
                {
                    var authorId = await GetAuthorIdBySurnameAsync(requestModel.AuthorSurname);
                    if (authorId == null)
                    {
                        Console.WriteLine("Author not found");
                        throw new NullReferenceException("Author not found");
                    }

                    var categoryIds = await GetCategoryIdsByNamesAsync(requestModel.CategoryNames);
                    foundElement.Title= requestModel.Title;
                    foundElement.Description= requestModel.Description;
                    foundElement.AuthorId = authorId.Value;
                    foundElement.CategoryIds = categoryIds;
                    var result = await Update(foundElement);
                    if (result is not null)
                    {
                        Console.WriteLine("Book updated");
                        return result;
                    }
                    throw new Exception("updated completed not successfully");    
                }
                throw new NullReferenceException("BookId not found");
            }
            catch (NullReferenceException nullEx)
            {
                Console.WriteLine(nullEx.ToString());
                throw;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
