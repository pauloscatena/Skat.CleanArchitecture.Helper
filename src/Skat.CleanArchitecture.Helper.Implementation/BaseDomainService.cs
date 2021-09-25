using Skat.CleanArchitecture.Helper.Abstractions.Entities;
using Skat.CleanArchitecture.Helper.Abstractions.Repository;
using Skat.CleanArchitecture.Helper.Abstractions.Services;
using System.Threading.Tasks;

namespace Skat.CleanArchitecture.Helper.Service
{
    public abstract class BaseDomainService<T, TId>: IDomainService<T, TId>
        where T: IEntity<TId>
    {
        private readonly IRepository<T, TId> _repository;
        protected BaseDomainService(IRepository<T, TId> repository)
        {
            _repository = repository;
        }

        public virtual async Task InsertAsync(T entity)
        {
            await _repository.InsertAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task<T> GetByIdAsync(TId id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task RemoveAsync(TId id)
        {
            await _repository.RemoveAsync(id);
        }
    }
}
