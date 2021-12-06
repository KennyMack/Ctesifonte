using AutoMapper;
using Ctesifonte.Application.Interfaces.ViewModels;
using Ctesifonte.Application.ViewModel;
using Ctesifonte.Domain.Base.Interfaces.Models;
using Ctesifonte.Domain.Base.Interfaces.Services;
using Ctesifonte.Domain.Base.Models;
using Ctesifonte.Infra.Cross.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ctesifonte.Application.Interfaces.Services
{
    public interface IBaseAppService<T> where T : BaseEntity
    {
        List<ModelException> Errors { get; set; }
        T Add(T model);
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);
        T GetById(Guid id, params Expression<Func<T, object>>[] includeProperties);
        T GetByIdToUpdate(Guid id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T Update(T model);
        void Remove(T model);
        Task<T> RemoveByIdAsync(Guid id);
        Task<int> SaveChangesAsync();
        void RollBackChanges();
        void Dispose();
    }
}
