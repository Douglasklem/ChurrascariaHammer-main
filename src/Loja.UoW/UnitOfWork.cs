using Churrascaria.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Churrascaria.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChurrascariaContext churrascariacontext;

        public UnitOfWork(ChurrascariaContext churrascariacontext)
        {
            this.churrascariacontext = churrascariacontext;
        }
        public async Task Commit()
        {
            await churrascariacontext.SaveChangesAsync();
        }

        public async Task Entry<TEntity>(TEntity _new, object key) where TEntity : class
        {
            var entity = await churrascariacontext.FindAsync<TEntity>(key);
            churrascariacontext.Entry(entity).CurrentValues.SetValues(_new);
            churrascariacontext.Entry(entity).State = EntityState.Detached;
        }

        public async Task RollBack()
        {
            var changedEntries = churrascariacontext.ChangeTracker.Entries()
               .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }

            await Task.CompletedTask;
        }
    }
}
