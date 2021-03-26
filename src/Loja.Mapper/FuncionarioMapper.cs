using AutoMapper;
using Churrascaria.Domain;
using Churrascaria.Interop.Dto;
using Churrascaria.Interop.ViewModel;

namespace Loja.Mapper
{
    public class FuncionarioMapper : Profile
    {
        public FuncionarioMapper()
        {
            CreateMap<FuncionarioViewModel, Funcionario>();
            CreateMap<Funcionario, FuncionarioDto>();
        }
    }
}
