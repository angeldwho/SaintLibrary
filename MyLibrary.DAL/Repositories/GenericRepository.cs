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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LibraryContext _libraryContext;
        public GenericRepository(LibraryContext libraryContext)
        {
                _libraryContext = libraryContext;
        }
        public async Task Create(T entity)
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
        public async Task<T> Update(T entity)
        {
            try
            {
                 _libraryContext.Set<T>().Update(entity);
                int affectedRows  = await _libraryContext.SaveChangesAsync();
                if (affectedRows > 0) { return entity; }
                throw new Exception("L'aggiornamento non ha avuto successo. Nessuna riga è stata modificata.");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task Delete(int id)
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
                Console.WriteLine(result);
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
                Console.WriteLine(result);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
