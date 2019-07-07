using Blog.ApplicationCore.Repositories.Interfaces;
using Blog.ApplicationCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Services
{
    public abstract class GenericService<T>: IGenericService<T>
    {
        protected IGenericRepository<T> genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async virtual Task Delete(object id)
        {
            await genericRepository.Delete(id);
        }

        public async virtual Task<T> Get(object id)
        {
            return await genericRepository.Get(id);
        }

        public async virtual Task<T> Insert(T entity)
        {
            return await genericRepository.Insert(entity);
        }

        public async virtual Task<T> Update(T entity)
        {
            return await genericRepository.Update(entity);
        }
       

        public async virtual Task DeleteAll(object[] ids)
        {
            await genericRepository.DeleteAll(ids);
        }

        public async Task UpdateAll(List<T> list)
        {
            await genericRepository.UpdateAll(list);
        }

        public async virtual Task InsertAll(List<T> list)
        {
            await genericRepository.InsertAll(list);
        }

        public virtual async Task<List<T>> List()
        {
            return await genericRepository.List();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposer)
        {
            if (disposer)
            {
                // dispose the managed objects
                genericRepository.Dispose();
            }
            // dispose the unmanaged objects
        }
    }
}
