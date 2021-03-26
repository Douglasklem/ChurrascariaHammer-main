
using AutoMapper;
using Churrascaria.Domain;
using Churrascaria.Interop.Dto;
using Churrascaria.Interop.ViewModel;

namespace Churrascaria.Mapper
{
    public class ParticipanteMapper : Profile
    {
        public ParticipanteMapper()
        {
            CreateMap<ParticipanteViewModel, Participante>();
            CreateMap<Participante, ParticipanteDto>();
        }
       
    }
}
