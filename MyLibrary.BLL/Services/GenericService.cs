using AutoMapper;
using MyLibrary.BLL.IServices;
using MyLibrary.BLL.Models.Request.CreateRequest;
using MyLibrary.BLL.Models.Request;
using MyLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DAL.IRepositories;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http.Headers;
using System.Dynamic;

namespace MyLibrary.BLL.Services
{
    public class GenericService<T,U,TEntity> : IGenericService<T,U,TEntity>
        where T : class
        where U : class
        where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TEntity> _genericRepository;
        public GenericService(IMapper mapper,IGenericRepository<TEntity> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task Create(T model)
        {
            try
            {
                if (model is not null)
                {
                    var toCreate = _mapper.Map<TEntity>(model);
                    await _genericRepository.Create(toCreate);
                }
                else { throw new Exception(); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task<U> Update(U model)
        {
            try
            {
                if (model is not null)
                {                    
                    var toCreate = _mapper.Map<TEntity>(model);
                    var entityReturn = await _genericRepository.Update(toCreate);
                    
                    if (entityReturn is null)
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var modelReturn = _mapper.Map<U>(entityReturn);
                        return modelReturn;
                    }
                    
                }
                else
                {
                    //uso della response in caso di errore
                    throw new NullReferenceException();
                }
            }
            catch (NullReferenceException nullEx)
            {
                Console.WriteLine(nullEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        public async Task Delete(int idObjectToDelete)
        {
            try
            {
                if (idObjectToDelete > 0)
                {
                    var found = _genericRepository.Find(idObjectToDelete);
                    if (found != null)
                        await _genericRepository.Delete(idObjectToDelete);
                }
                else
                {
                    throw new Exception();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async Task<U> Find(int idObjectToFind)
        {
            try
            {
                if (idObjectToFind > 0)
                {
                    var found = await _genericRepository.Find(idObjectToFind);
                    if(found is not null)
                    {
                        var modelReturn = _mapper.Map<U>(found);
                        return modelReturn;
                    }
                    throw new NullReferenceException();
                }
                else
                {
                    throw new Exception();
                }


            }
            catch (NullReferenceException nullEx)
            {
                Console.WriteLine(nullEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<IList<U>> GetAll()
        {
            try
            {
                var objects = await _genericRepository.GetAll();
                return _mapper.Map<IList<U>>(objects);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
