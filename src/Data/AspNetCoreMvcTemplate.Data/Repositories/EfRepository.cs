namespace AspNetCoreMvcTemplate.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.EntityFrameworkCore;

    public class EfRepository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        public EfRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        public ApplicationDbContext Context { get; }

        public DbSet<TEntity> DbSet { get; }

        public async Task AddAsync(TEntity entity) 
            => await this.Context.AddAsync(entity);

        public IQueryable<TEntity> All()
            => this.DbSet;

        public void Delete(TEntity entity)
            => this.DbSet.Remove(entity);

        public void Dispose()
            => this.Context.Dispose();

        public Task<int> SaveChangesAsync()
            => this.Context.SaveChangesAsync();

        public void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
