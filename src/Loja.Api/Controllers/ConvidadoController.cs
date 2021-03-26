using AutoMapper;
using Churrascaria.AppService.Contracts;
using Churrascaria.Domain;
using Churrascaria.Interop.Dto;
using Churrascaria.Interop.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Churrascaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvidadoController : ControllerBase
    {
        private readonly IConvidadoAppService convidadoAppService;
        private readonly IMapper mapper;

        public ConvidadoController(IConvidadoAppService convidadoAppService, IMapper mapper)
        {
            this.convidadoAppService = convidadoAppService;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Post(ConvidadoViewModel convidadoViewModel)
        {
               await convidadoAppService.Gravar(mapper.Map<Convidado>(convidadoViewModel));

                return Ok("Convidado cadastrada com sucesso");
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<ICollection<ConvidadoDto>>(await convidadoAppService.Listar()));
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(ConvidadoViewModel convidadoView)
        {
            await convidadoAppService.Deletar(convidadoView.Id);

            return Ok("Convidado excluido");
        }
    }
}