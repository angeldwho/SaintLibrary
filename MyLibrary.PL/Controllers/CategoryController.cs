using Microsoft.AspNetCore.Mvc;
using MyLibrary.BLL.IServices;

namespace MyLibrary.PL.Controllers
{
    [Controller]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
