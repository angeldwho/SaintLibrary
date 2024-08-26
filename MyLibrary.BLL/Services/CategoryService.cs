using AutoMapper;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Models;
using MyLibrary.DAL.Entities;
using MyLibrary.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Create(CategoryModel categoryModel)
        {
            if (categoryModel is not null)
            {
                var categoryToCreate = _mapper.Map<Category>(categoryModel);
                //await
                 _categoryRepository.Create(categoryToCreate);
            }else { throw new Exception();}
            
        }


    }
}
