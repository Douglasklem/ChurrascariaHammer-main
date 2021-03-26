using System.Collections.Generic;
using System.Threading.Tasks;

namespace Churrascaria.AppService.Contracts
{
    public interface IAppService<TEntity>
    {
        Task Gravar(TEntity entity);
        Task Alterar(TEntity entity);
        Task Deletar(int Id);
        Task<ICollection<TEntity>> Listar();

    }
}
