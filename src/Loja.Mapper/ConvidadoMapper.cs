using AutoMapper;
using Churrascaria.Domain;
using Churrascaria.Interop.Dto;
using Churrascaria.Interop.ViewModel;

namespace Churrascaria.Mapper
{
    public class ConvidadoMapper : Profile
    {
        public ConvidadoMapper()
        {
            CreateMap<ConvidadoViewModel, Convidado>();
            CreateMap<Convidado, ConvidadoDto>();
        }
    }
}
