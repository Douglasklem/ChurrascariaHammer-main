using Churrascaria.Domain;
using Churrascaria.Data.Context;
using Churrascaria.Domain.Contracts;

namespace Churrascaria.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(ChurrascariaContext lojaContext) : base(lojaContext)
        {
        }
    }
}
