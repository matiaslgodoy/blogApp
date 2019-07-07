using Common.Generic.Repositories.Entities;
using Common.Generic.Repositories.Paginators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Generic.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DbContext dbContext;

        protected DbSet<TEntity> dbSet;

        protected UserData userData = new UserData();

        UserData IGenericRepository<TEntity>.UserData { get => this.userData; }

        public GenericRepository(DbContext dbContext)
        {
            this.dbSet = dbContext.Set<TEntity>();
            this.dbContext = dbContext;
        }

        public async virtual Task Delete(object id)
        {
            var entity = await dbSet.FindAsync(id);
            this.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        private void Remove(TEntity entity)
        {

            if (entity is ISoftDelete)
            {
                (entity as ISoftDelete).IsDeleted = true;
                dbSet.Update(entity);
            }
            else
            {
                dbSet.Remove(entity);
            }
        }

        public async virtual Task DeleteAll(object[] ids)
        {
            foreach (var item in ids)
            {
                this.Remove(dbSet.Find(item));
            }

            await dbContext.SaveChangesAsync();

        }

        public async virtual Task<TEntity> Get(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task<TEntity> Insert(TEntity entity)
        {
            var result = (await dbSet.AddAsync(entity)).Entity;
            await dbContext.SaveChangesAsync();
            return result;
        }

        public async virtual Task InsertAll(List<TEntity> list)
        {
            await dbSet.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
        }

        public async virtual Task<TEntity> Update(TEntity entity)
        {
            var result = dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async virtual Task UpdateAll(List<TEntity> list)
        {
            dbSet.UpdateRange(list);
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> List()
        {
            return await dbSet.ToListAsync<TEntity>();
        }

        public async virtual Task<Paginator<TEntity>> List(int page, int rowsPage)
        {
            return new Paginator<TEntity>
            {
                Result = await dbSet.Skip<TEntity>(page * rowsPage).Take<TEntity>(rowsPage).ToListAsync<TEntity>(),
                TotalRow = await dbSet.CountAsync<TEntity>()
            };
        }

        ~GenericRepository()
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
                dbContext.Dispose();
            }
        }



        public void SetUserName(string username)
        {
            this.userData.UserName = username;
        }

        public void SetUserPersonName(string personName)
        {
            this.userData.UserPersonName = personName;
        }

        public void SetUserId(string userId)
        {
            this.userData.UserId = userId;
        }

        public void SetUserRole(string userRole)
        {
            this.userData.Role = userRole;
        }

    }
}
