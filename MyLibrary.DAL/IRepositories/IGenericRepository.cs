using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
        Task<IList<T>> GetAll();
        Task<T> Find(int id);

    }
}
