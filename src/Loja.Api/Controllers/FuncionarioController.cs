using AutoMapper;
using Churrascaria.Domain;
using Churrascaria.AppService.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Churrascaria.Interop.ViewModel;
using Churrascaria.Interop.Dto;

namespace Churrascaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioAppService FuncionarioAppService;
        private readonly IConvidadoAppService ConvidadoAppService;
        private readonly IMapper mapper;

        public FuncionarioController(IFuncionarioAppService FuncionarioAppService, IMapper mapper,IConvidadoAppService convidadoAppService)
        {
            this.FuncionarioAppService = FuncionarioAppService;
            this.mapper = mapper;
            this.ConvidadoAppService = convidadoAppService;

        }


        [HttpPost]
        public async Task<IActionResult> Post(FuncionarioViewModel funcionarioViewModel)
        {
            await FuncionarioAppService.Gravar(mapper.Map<Funcionario>(funcionarioViewModel));
            return Ok("Funcionario cadastrada com sucesso");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<ICollection<FuncionarioDto>>(await FuncionarioAppService.Listar()));
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(FuncionarioViewModel funcionarioViewModel)
        {
            await FuncionarioAppService.Deletar(funcionarioViewModel.Id);
            return Ok("Funcionario excluído com sucesso");
        }
    }
}
