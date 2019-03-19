namespace TicketStore.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using TicketStore.Data.Common.Repositories;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public Repository(TicketStoreDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected TicketStoreDbContext Context { get; set; }

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

        public virtual Task<TEntity> GetByIdAsync(params object[] id) => this.DbSet.FindAsync(id);

        public virtual TEntity GetById(params object[] id) => this.DbSet.Find(id);

        public virtual void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public Task AddAsync(TEntity entity)
        {
            return this.DbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public void Dispose() => this.Context.Dispose();
    }
}
