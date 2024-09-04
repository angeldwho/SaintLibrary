using AutoMapper;
using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.Configuration
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<AuthorCreateRequestModel, Author>();
            CreateMap<AuthorRequestModel, Author>().IncludeBase<AuthorCreateRequestModel, Author>();
            CreateMap<Author, AuthorRequestModel>();

            CreateMap<BookCreateRequestModel, Book>().ReverseMap();
            CreateMap<BookRequestModel, Book>().IncludeBase<BookCreateRequestModel, Book>();
            CreateMap<Book, BookRequestModel>();

            CreateMap<CategoryCreateRequestModel, Category>();
            CreateMap<CategoryRequestModel, Category>().IncludeBase<CategoryCreateRequestModel, Category>();
            CreateMap<Category, CategoryRequestModel>();

        }
    }
}
