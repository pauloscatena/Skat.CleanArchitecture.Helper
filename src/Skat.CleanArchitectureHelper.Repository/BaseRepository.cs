using Microsoft.EntityFrameworkCore;
using Skat.CleanArchitecture.Helper.Abstractions.Entities;
using Skat.CleanArchitecture.Helper.Abstractions.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Skat.CleanArchitectureHelper.Repository
{
    public abstract class BaseRepository<T, TId>: DbContext, IRepository<T, TId>
        where T: class, IEntity<TId>
    {
        public BaseRepository(DbContextOptions options): base(options)
        {
        }

        private DbSet<T> _entity;

        protected DbSet<T> Entity
        {
            get
            {
                return _entity;
            }
        }


        protected virtual IQueryable<T> BaseQuery()
        {
            return _entity.AsNoTracking();
        }

        public async Task InsertAsync(T entity)
        {
            await _entity.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _entity.Update(entity);
            await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await BaseQuery().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task RemoveAsync(TId id)
        {
            var entity = await GetByIdAsync(id);
            _entity.Remove(entity);
            await SaveChangesAsync();
        }
    }
}
