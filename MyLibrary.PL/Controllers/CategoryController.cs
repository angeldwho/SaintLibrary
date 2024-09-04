using Microsoft.AspNetCore.Mvc;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Models.Request.CreateRequest;

namespace MyLibrary.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Create")]
        public Task CreateCategory([FromBody]CategoryCreateRequestModel requestModel)
        {
            return _categoryService.Create(requestModel);
        }
        [HttpPut("Update")]
        public IActionResult UpdateCategory([FromBody] CategoryRequestModel requestModel)
        {
            var result = _categoryService.Find(requestModel.ID).IsCompletedSuccessfully;
            if (result is true)
                return Ok(_categoryService.Update(requestModel));
            else return NotFound();
        }
        [HttpDelete]
        public Task Delete(int id)
        {
            return _categoryService.Delete(id);
        }

        [HttpGet("GetAll")]
        public Task<IList<CategoryRequestModel>> GetAll()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("Find")]
        public Task<CategoryRequestModel> Find(int id)
        {
            return _categoryService.Find(id);
        }
    }
}
