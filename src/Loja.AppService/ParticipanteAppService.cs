using Churrascaria.AppService.Contracts;
using Churrascaria.Domain;
using Churrascaria.Domain.Contracts;
using Churrascaria.UoW;

namespace Churrascaria.AppService
{
    public class ParticipanteAppService : AppService<Participante>, IParticipanteAppService
    {
        private readonly IParticipanteRepository repository;

        public ParticipanteAppService(IParticipanteRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
        }
    }
}
