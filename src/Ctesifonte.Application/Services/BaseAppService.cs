using AutoMapper;
using Ctesifonte.Application.Interfaces.Services;
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

namespace Ctesifonte.Application.Services
{
    public class BaseAppService<T> : IBaseAppService<T>, IDisposable where T : BaseEntity
    {
        protected readonly IMapper _mapper;
        private readonly IBaseService<T> _BaseService;
        public List<ModelException> Errors
        {
            get => _BaseService.Errors;
            set => _BaseService.Errors = value;
        }

        public BaseAppService(IMapper mapper, IBaseService<T> baseService)
        {
            _mapper = mapper;
            _BaseService = baseService;
        }

        public virtual T Add(T model)
        {
            _BaseService.Add(model);
            return model;
        }

        public virtual T Update(T model)
        {
            _BaseService.Update(model);
            return model;
        }

        public virtual void Remove(T model) =>
            _BaseService.Remove(model);

        public virtual async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties) =>
            await _BaseService.GetAllAsync(includeProperties);

        public virtual T GetById(Guid id, params Expression<Func<T, object>>[] includeProperties) =>
            _BaseService.GetById(id, includeProperties);

        public virtual async Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties) =>
            await _BaseService.GetByIdAsync(id, includeProperties);

        public virtual T GetByIdToUpdate(Guid id) =>
            _BaseService.GetByIdToUpdate(id);

        public virtual async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) =>
            await _BaseService.QueryAsync(predicate, includeProperties);        

        public virtual async Task<T> RemoveByIdAsync(Guid id) =>
            await _BaseService.RemoveByIdAsync(id);

        public virtual void RollBackChanges() =>
            _BaseService.RollBackChanges();

        public virtual async Task<int> SaveChangesAsync() =>
            await _BaseService.SaveChangesAsync();

        public void Dispose()
        {
            _BaseService.Dispose();
        }
    }
}
