using Blog.ApplicationCore.Services.Interfaces;
using Common.Generic.Repositories;
using Common.Generic.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Generic.Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : class
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

        public virtual async Task<List<T>> List()
        {
            return await genericRepository.List();
        }

        public async virtual Task<PaginatorResponseModel<T>> List(PaginatorRequestModel requestModel)
        {
            var paginator = await genericRepository.List(requestModel.Page, requestModel.RowsPage);
            return new PaginatorResponseModel<T>
            {
                ResultList = paginator.Result,
                TotalRows = paginator.TotalRow
            };
        }

        ~GenericService()
        {
            Dispose(false);
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


        public virtual void SetUserName(string username)
        {
            this.genericRepository.SetUserName(username);
        }

        public virtual void SetUserPersonName(string personName)
        {
            this.genericRepository.SetUserPersonName(personName);
        }

        public virtual void SetUserId(string userId)
        {
            this.genericRepository.SetUserId(userId);
        }

        public virtual void SetUserRole(string userRole)
        {
            this.genericRepository.SetUserRole(userRole);
        }

    }
}
