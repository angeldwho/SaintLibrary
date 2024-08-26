using AutoMapper;
using MyLibrary.BLL.Models;
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
            CreateMap<Author, AuthorModel>();
            CreateMap<Book, BookModel>();
            CreateMap<Category, CategoryModel>();
        }
    }
}
