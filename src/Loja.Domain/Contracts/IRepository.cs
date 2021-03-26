using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Churrascaria.Domain.Contracts
{
    public interface IRepository<TEntity>
    {
        Task Gravar(TEntity entity);
        Task Alterar(TEntity entity);
        Task Deletar(int Id);
        Task<ICollection<TEntity>> Listar();
    }
}
