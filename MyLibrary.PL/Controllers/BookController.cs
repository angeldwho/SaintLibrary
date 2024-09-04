using Microsoft.AspNetCore.Mvc;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Models.Request.CreateRequest;

namespace MyLibrary.PL.Controllers
{
    [Controller]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) 
        { 
            _bookService = bookService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BookCreateRequestModel requestModel)
        {
           await _bookService.CreateBook(requestModel);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<BookRequestModel> Update([FromBody] BookRequestModel requestModel)
        {
            var result = await _bookService.UpdateBook(requestModel);
            return result;
        }
        [Route("{id:int}")]
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _bookService.Delete(id);
        }

        [HttpGet("GetAll")]
        public async Task<IList<BookRequestModel>> GetAll()
        {
            return await _bookService.GetAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public async  Task<BookRequestModel> Find(int id)
        {
            return await _bookService.Find(id);
        }
        
    }
}
