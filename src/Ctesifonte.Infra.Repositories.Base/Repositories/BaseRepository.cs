using Ctesifonte.Domain.Base.Interfaces.Repositories;
using Ctesifonte.Domain.Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Infra.Repositories.Base.Repositories
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
    {
        protected DbContext DbConn;
        protected DbSet<T> DbEntity;

        public BaseRepository(DbContext appDbContext)
        {
            DbConn = appDbContext;
            DbEntity = DbConn.Set<T>();
        }

        protected IQueryable<T> AddQueryProperties(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties)
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.AsNoTracking();
        }

        public virtual void Add(T model)
        {
            model.Created = DateTime.Now;
            model.Modified = DateTime.Now;
            if (model.Id == Guid.Empty)
                model.Id = Guid.NewGuid();

            DbEntity.Add(model);
        }

        public virtual void Update(T model)
        {
            model.Modified = DateTime.Now;
            var entry = DbConn.Entry(model);
            if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
            {
                entry.State = EntityState.Modified;

                DbConn.Set<T>().Attach(model);
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties) =>
            await DbEntity.ToListAsync();

        public virtual T GetById(Guid id, params Expression<Func<T, object>>[] includeProperties) =>
            DbConn.Find<T>(id);

        public virtual async Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties) => 
            await DbConn.FindAsync<T>(id);

        public virtual T GetByIdToUpdate(Guid id) =>
            DbConn.Find<T>(id);

        public virtual async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) =>
            await AddQueryProperties(DbEntity, includeProperties)
                            .AsNoTracking()
                            .Where(predicate)
                            .ToListAsync();

        public virtual void Remove(T model)
        {
            DbEntity.Attach(model);
            DbConn.Entry(model).State = EntityState.Deleted;
            DbEntity.Remove(model);
        }

        public async Task<T> RemoveByIdAsync(Guid id)
        {
            var model = await Task.Run(() => GetByIdToUpdate(id));
            Remove(model);
            return model;
        }

        public virtual void RollBackChanges()
        {
            var changedEntries = DbConn.ChangeTracker.Entries()
                   .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            var ret = -1;
            try
            {
                ret = await DbConn.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                /*
                Logging.Exception(e);
                if (!AppSettings.IsDebug)
                {
                    if (e.InnerException.InnerException is OracleException)
                    {
                        var sqlex = e.InnerException.InnerException as OracleException;
                        throw new DBOracleCodeException(sqlex);
                    }
                }
                */
                throw;
            }
            catch (Exception e)
            {
                // Logging.Exception(e);
                throw;
            }

            return ret;
        }

        public void Dispose()
        {
            DbConn.Dispose();
        }
    }
}
