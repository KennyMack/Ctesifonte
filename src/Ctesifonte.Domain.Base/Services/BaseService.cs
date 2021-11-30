using Ctesifonte.Domain.Base.Interfaces.Exceptions;
using Ctesifonte.Domain.Base.Interfaces.Repositories;
using Ctesifonte.Domain.Base.Interfaces.Services;
using Ctesifonte.Infra.Cross.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ctesifonte.Domain.Base.Services
{
    public class BaseService<T> : IDisposable, IBaseService<T> where T : class
    {
        public IBaseRepository<T> DataRepository { get; }
        public List<ModelException> Errors { get; set; }


        public BaseService(IBaseRepository<T> repo)
        {
            DataRepository = repo;
            Errors = new List<ModelException>();
        }

        public virtual T Add(T model)
        {
            try
            {
                DataRepository.Add(model);
            }
            catch (Exception e)
            {
                Errors.Add(new ModelException
                {
                    ErrorCode = (int)EExceptionErrorCodes.InsertSQLError,
                    Field = e.HelpLink,
                    Value = e.Source,
                    Messages = new string[] { e.Message,
                                              e?.InnerException?.Message,
                                              e?.InnerException?.InnerException?.Message  }
                });
            }
            return model;
        }

        public virtual T Update(T model)
        {
            try
            {
                DataRepository.Update(model);
            }
            catch (Exception e)
            {
                Errors.Add(new ModelException
                {
                    ErrorCode = (int)EExceptionErrorCodes.UpdateSQLError,
                    Field = e.HelpLink,
                    Value = e.Source,
                    Messages = new string[] { e.Message,
                                              e?.InnerException?.Message,
                                              e?.InnerException?.InnerException?.Message }
                });
            }
            return model;
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties) =>
            await DataRepository.GetAllAsync(includeProperties);

        public virtual T GetById(Guid id, params Expression<Func<T, object>>[] includeProperties) =>
            DataRepository.GetById(id, includeProperties);

        public virtual async Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties) =>
            await DataRepository.GetByIdAsync(id, includeProperties);

        public virtual T GetByIdToUpdate(Guid id) =>
            DataRepository.GetByIdToUpdate(id);

        public virtual async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) =>
            await DataRepository.QueryAsync(predicate, includeProperties);

        public virtual void Remove(T model)
        {
            try
            {
                DataRepository.Remove(model);
            }
            catch (Exception e)
            {
                Errors.Add(new ModelException
                {
                    ErrorCode = (int)EExceptionErrorCodes.DeleteSQLError,
                    Field = e.HelpLink,
                    Value = e.Source,
                    Messages = new string[] { e.Message,
                                              e?.InnerException?.Message,
                                              e?.InnerException?.InnerException?.Message  }
                });
            }
        }

        public virtual async Task<T> RemoveByIdAsync(Guid id)
        {
            try
            {
                var model = await DataRepository.RemoveByIdAsync(id);
                return model;
            }
            catch (Exception e)
            {
                Errors.Add(new ModelException
                {
                    ErrorCode = (int)EExceptionErrorCodes.DeleteSQLError,
                    Field = e.HelpLink,
                    Value = e.Source,
                    Messages = new string[] { e.Message,
                                              e?.InnerException?.Message,
                                              e?.InnerException?.InnerException?.Message }
                });
            }
            return default;
        }

        public void RollBackChanges() =>
            DataRepository.RollBackChanges();

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var ret = await DataRepository.SaveChangesAsync();

                return ret;
            }
            catch (Exception e)
            {
                if (e is IModelEntityValidationException exception)
                    Errors = exception.MException;
                else
                {
                    Errors.Add(new ModelException
                    {
                        ErrorCode = (int)EExceptionErrorCodes.SaveSQLError,
                        Field = e.HelpLink,
                        Value = e.Source,
                        Messages = new string[] { e.Message,
                                              e?.InnerException?.Message,
                                              e?.InnerException?.InnerException?.Message }
                    });
                }
            }
            return -1;
        }

        public void Dispose()
        {
            DataRepository.Dispose();
        }
    }
}
