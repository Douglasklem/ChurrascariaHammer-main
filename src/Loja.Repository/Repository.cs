using Churrascaria.Data.Context;
using Churrascaria.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Churrascaria.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ChurrascariaContext lojaContext;
        public DbSet<TEntity> dbSet { get; set; }

        public Repository(ChurrascariaContext lojaContext)
        {
            this.lojaContext = lojaContext;
            dbSet = lojaContext.Set<TEntity>();
        }

        public virtual async Task Alterar(TEntity entity)
        {
            dbSet.Update(entity);
            await Task.CompletedTask;
        }

        public virtual async Task Deletar(int Id)
        {
            dbSet.Remove(dbSet.Find(Id));
            await Task.CompletedTask;
        }

        public virtual async Task Gravar(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task<ICollection<TEntity>> Listar()
        {
            return await dbSet.ToListAsync();
        }
    }
}
