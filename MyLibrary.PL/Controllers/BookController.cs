using Microsoft.AspNetCore.Mvc;
using MyLibrary.DAL.IRepositories;

namespace MyLibrary.PL.Controllers
{
    [Controller]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository) 
        { 
            _bookRepository = bookRepository;
        }
        
    }
}
