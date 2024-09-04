using MyLibrary.BLL.Models.Request;
using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.IServices
{
    public interface ICategoryService : IGenericService<CategoryCreateRequestModel,CategoryRequestModel,Category>
    {
    }
}
