using System.Threading.Tasks;

namespace Churrascaria.UoW
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task RollBack();

        Task Entry<TEntity>(TEntity _new, object key) where TEntity : class;
    }
}
