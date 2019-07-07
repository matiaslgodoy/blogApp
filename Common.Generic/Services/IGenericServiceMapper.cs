using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Generic.Services
{
    public interface IGenericServiceMapper<TMapper> : IDisposable where TMapper : class
    {
        Task<TMapper> Get(object id);

        Task Delete(object id);

        Task DeleteAll(object[] ids);

        Task<TMapper> Update(TMapper entity);

        Task UpdateAll(List<TMapper> entity);

        Task<TMapper> Insert(TMapper entity);

        Task InsertAll(List<TMapper> list);

        Task<List<TMapper>> List();

        void SetUserName(string username);

        void SetUserPersonName(string personName);

        void SetUserId(string userId);

        void SetUserRole(string userRole);

    }
}
