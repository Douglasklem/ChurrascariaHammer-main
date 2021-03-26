using AutoMapper;
using Churrascaria.AppService.Contracts;
using Churrascaria.Domain;
using Churrascaria.Domain.Contracts;
using Churrascaria.UoW;
using System.Threading.Tasks;

namespace Churrascaria.AppService
{
    public class ConvidadoAppService : AppService<Convidado>, IConvidadoAppService
    {
        private readonly IConvidadoRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ConvidadoAppService(IConvidadoRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public override async Task Alterar(Convidado convidado)
        {
            await unitOfWork.Entry(convidado, convidado.Id);

            await base.Alterar(convidado);
        }

        public override Task Gravar(Convidado convidado)
        {
            return base.Gravar(convidado);
        }
        public override Task Deletar(int Id)
        {
            return base.Deletar(Id);
        }
    }
}
