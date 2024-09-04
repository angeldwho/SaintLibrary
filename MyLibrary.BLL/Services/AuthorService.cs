using AutoMapper;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.DAL.Entities;
using MyLibrary.DAL.IRepositories;
using MyLibrary.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.Services
{
    public class AuthorService : GenericService<AuthorCreateRequestModel,AuthorRequestModel,Author>,IAuthorService
    {
        public AuthorService(IMapper mapper,IGenericRepository<Author> genericRepository) : base(mapper,genericRepository)
        {
        }
    }
}
