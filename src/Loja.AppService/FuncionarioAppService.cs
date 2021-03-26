using AutoMapper;
using Churrascaria.AppService.Contracts;
using Churrascaria.Domain;
using Churrascaria.Domain.Contracts;
using Churrascaria.UoW;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Churrascaria.AppService
{
    public class FuncionarioAppService : AppService<Funcionario>, IFuncionarioAppService
    {
        private readonly IFuncionarioRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public FuncionarioAppService(IFuncionarioRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public override Task Gravar(Funcionario funcionario)
        {
            return base.Gravar(funcionario);
        }

        public override Task Deletar(int Id)
        {
            return base.Deletar(Id);
        }

        public override Task Alterar(Funcionario funcionario)
        {
            return base.Alterar(funcionario);
        }
        public override Task<ICollection<Funcionario>> Listar()
        {
            return base.Listar();
        }
    }
}
