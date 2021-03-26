using Churrascaria.Domain;
using Churrascaria.Data.Context;
using Churrascaria.Domain.Contracts;

namespace Churrascaria.Repository
{
    public class ConvidadoRepository : Repository<Convidado>, IConvidadoRepository
    {
        public ConvidadoRepository(ChurrascariaContext lojaContext) : base(lojaContext)
        {
        }

    }
}
