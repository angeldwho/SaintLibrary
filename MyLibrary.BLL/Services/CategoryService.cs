using AutoMapper;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.BLL.Models.Response;
using MyLibrary.DAL.Entities;
using MyLibrary.DAL.IRepositories;
using MyLibrary.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.Services
{
    public class CategoryService : GenericService<CategoryCreateRequestModel,CategoryRequestModel,Category>,ICategoryService
    {
       
        public CategoryService(IMapper mapper, IGenericRepository<Category> categoryRepository) : base(mapper,categoryRepository)
        {
            
        }

        
    }
}
