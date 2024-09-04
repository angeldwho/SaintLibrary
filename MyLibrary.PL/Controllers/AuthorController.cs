using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Services;

namespace MyLibrary.PL.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost("Create")]
        public Task Create([FromBody] AuthorCreateRequestModel requestModel)
        {
            return _authorService.Create(requestModel);
        }
        [HttpPut("Update")]
        public async Task<AuthorRequestModel> Update([FromBody] AuthorRequestModel requestModel)
        {
            var foundElement = _authorService.Find(requestModel.ID).IsCompletedSuccessfully;
            if (foundElement is true)
            {
               var modelUpdated = await _authorService.Update(requestModel);
                if (modelUpdated != null)
                {
                    return modelUpdated;
                }
                else
                {
                    throw new Exception();
                }
                throw new Exception();
            }
            throw new Exception();
        }
        [Route("{id:int}")]
        [HttpDelete]
        public Task Delete(int id)
        {
            return _authorService.Delete(id);
        }

        [HttpGet("GetAll")]
        public Task<IList<AuthorRequestModel>> GetAll()
        {
            return _authorService.GetAll();
        }

        [Route("{id:int}")]
        [HttpGet]
        public Task<AuthorRequestModel> Find(int id)
        {
            return _authorService.Find(id);
        }
    }
}
