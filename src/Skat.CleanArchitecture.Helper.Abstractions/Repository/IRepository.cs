using Skat.CleanArchitecture.Helper.Abstractions.Entities;
using System.Threading.Tasks;

namespace Skat.CleanArchitecture.Helper.Abstractions.Repository
{
    public interface IRepository<T, TId>
        where T: IEntity<TId>
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(TId id);
        Task RemoveAsync(TId id);
    }
}
