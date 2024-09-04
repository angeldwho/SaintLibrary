using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.BLL.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL.IServices
{
    public interface IGenericService<T,U,Z> 
        where T : class
        where U : class
        where Z : class
    {
        Task Create(T model);
        Task<U> Update(U model);
        Task Delete(int id);
        Task<U> Find(int id);
        Task<IList<U>> GetAll();
    }
}
