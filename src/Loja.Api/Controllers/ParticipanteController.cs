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
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteAppService participanteAppService;
        private readonly IMapper mapper;

        public ParticipanteController(IParticipanteAppService participanteAppService, IMapper mapper)
        {
            this.participanteAppService = participanteAppService;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Post(ParticipanteViewModel participanteViewModel)
        {
            await participanteAppService.Gravar(mapper.Map<Participante>(participanteViewModel));

            return Ok("Convidado cadastrada com sucesso");

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(mapper.Map<ICollection<ParticipanteDto>>(await participanteAppService.Listar()));
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(ParticipanteViewModel participanteViewModel)
        {
            await participanteAppService.Deletar(participanteViewModel.Id);

            return Ok("Convidado excluido");
        }
    }
}
