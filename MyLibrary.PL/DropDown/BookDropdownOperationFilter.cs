using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MyLibrary.BLL.IServices;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyLibrary.PL.DropDown
{
    public class BookDropdownOperationFilter : IOperationFilter
    {
        private readonly IBookService _bookService;
        public BookDropdownOperationFilter(IBookService bookService)
        {
            _bookService = bookService;
        }
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authorParameter = operation.Parameters.FirstOrDefault(p => p.Name == "AuthorLastname");
            var categoriesParameter = operation.Parameters.FirstOrDefault(p => p.Name == "CategoryNames");

            if (authorParameter != null)
            {
                var authorSurnames = _bookService.GetAuthorSurnamesAsync().Result;
                authorParameter.Schema.Enum = authorSurnames.Select(a => new OpenApiString(a.Value)).ToList<IOpenApiAny>();
            }

            if (categoriesParameter != null)
            {
                var categoryNames = _bookService.GetCategoryNamesAsync().Result;
                categoriesParameter.Schema.Enum = categoryNames.Select(c => new OpenApiString(c.Value)).ToList<IOpenApiAny>();
            }
        }
    }
}
