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

        public IQueryable<TEntity> All()
            => this.DbSet;

        public Task AddAsync(TEntity entity)
            => this.Context.AddAsync(entity);

        public void Delete(TEntity entity)
            => this.DbSet.Remove(entity);

        public Task<int> SaveChangesAsync()
            => this.Context.SaveChangesAsync();

        public void Dispose()
            => this.Context.Dispose();

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
