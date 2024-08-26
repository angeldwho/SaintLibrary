using Microsoft.EntityFrameworkCore;
using MyLibrary.DAL.Data;
using MyLibrary.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LibraryContext _libraryContext;
        public GenericRepository(LibraryContext libraryContext)
        {
                _libraryContext = libraryContext;
        }
        public async void Create(T entity)
        {
            try
            {
                _libraryContext.Set<T>().Add(entity);
                await _libraryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async void Update(T entity)
        {
            try
            {
                _libraryContext.Set<T>().Update(entity);
                await _libraryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async void Delete(int id)
        {
            try
            {
                var entityToRemove = await Find(id);
                _libraryContext.Set<T>().Remove(entityToRemove);
                await _libraryContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<T> Find(int id)
        {
            try
            {
                var result = await _libraryContext.Set<T>().FindAsync(id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            //find async ritorna null se non trova
        }
        public async Task<IList<T>> GetAll()
        {
            try
            {
                var result = await _libraryContext.Set<T>().ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
