using Blog.ApplicationCore.Services.Interfaces;
using Common.Generic.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Generic.Services
{
    public interface IGenericService<T> : IDisposable where T : class
    {
        Task<T> Get(object id);

        Task Delete(object id);

        Task DeleteAll(object[] ids);

        Task<T> Update(T entity);

        Task UpdateAll(List<T> entity);

        Task<T> Insert(T entity);

        Task InsertAll(List<T> list);

        Task<List<T>> List();

        Task<PaginatorResponseModel<T>> List(PaginatorRequestModel requestModel);

        void SetUserName(string username);

        void SetUserPersonName(string personName);

        void SetUserId(string userId);

        void SetUserRole(string userRole);

    }
}
