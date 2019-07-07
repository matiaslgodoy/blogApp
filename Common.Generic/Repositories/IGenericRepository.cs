using Common.Generic.Repositories.Paginators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Generic.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Delete(object id);

        Task DeleteAll(object[] ids);

        Task<TEntity> Get(object id);

        Task<TEntity> Insert(TEntity entity);

        Task InsertAll(List<TEntity> list);

        Task<TEntity> Update(TEntity entity);

        Task UpdateAll(List<TEntity> list);

        Task<List<TEntity>> List();

        Task<Paginator<TEntity>> List(int page, int rowsPage);

        void SetUserName(string username);

        void SetUserPersonName(string personName);

        void SetUserId(string userId);

        void SetUserRole(string userRole);

        UserData UserData { get; }

    }
}
