using Churrascaria.Data.Context;
using Churrascaria.Domain;
using Churrascaria.Domain.Contracts;

namespace Churrascaria.Repository
{
    public class ParticipanteRepository : Repository<Participante>, IParticipanteRepository
    {
        public ParticipanteRepository(ChurrascariaContext lojaContext) : base(lojaContext)
        {
        }
    }
}
