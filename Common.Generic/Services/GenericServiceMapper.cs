using Common.Generic.Repositories;
using Common.Generic.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.ApplicationCore.Services.Interfaces;

namespace Common.Generic.Services
{
    public abstract class GenericServiceMapper<T, TMapper> : IGenericServiceMapper<TMapper> where T : class where TMapper : class
    {
        protected IGenericRepository<T> genericRepository;

        public GenericServiceMapper(IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;

        }

        public async virtual Task Delete(object id)
        {
            await genericRepository.Delete(id);
        }

        public async virtual Task<TMapper> Get(object id)
        {
            return Mapper.Map<TMapper>(await genericRepository.Get(id));
        }

        public async virtual Task<TMapper> Insert(TMapper entity)
        {
            return Mapper.Map<TMapper>(await genericRepository.Insert(Mapper.Map<T>(entity)));

        }

        public async virtual Task<TMapper> Update(TMapper entity)
        {

            return Mapper.Map<TMapper>(await genericRepository.Update(Mapper.Map<T>(entity)));
        }

        public virtual async Task<List<TMapper>> List()
        {
            return Mapper.Map<List<TMapper>>(await genericRepository.List());
        }

        public async virtual Task<PaginatorResponseModel<TMapper>> List(PaginatorRequestModel requestModel)
        {
            var paginator = await genericRepository.List(requestModel.Page, requestModel.RowsPage);
            return new PaginatorResponseModel<TMapper>
            {
                ResultList = Mapper.Map<List<TMapper>>(paginator.Result),
                TotalRows = paginator.TotalRow
            };
        }

        ~GenericServiceMapper()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposer)
        {
            if (disposer)
            {
                genericRepository.Dispose();
            }
        }

        public async virtual Task DeleteAll(object[] ids)
        {
            await genericRepository.DeleteAll(ids);
        }

        public async Task UpdateAll(List<TMapper> list)
        {
            await genericRepository.UpdateAll(Mapper.Map<List<T>>(list));
        }

        public async virtual Task InsertAll(List<TMapper> list)
        {

            await genericRepository.InsertAll(Mapper.Map<List<T>>(list));
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
