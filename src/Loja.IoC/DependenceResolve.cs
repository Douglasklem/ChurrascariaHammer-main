using Churrascaria.AppService;
using Churrascaria.AppService.Contracts;
using Churrascaria.Data.Context;
using Churrascaria.Domain.Commun;
using Churrascaria.Domain.Contracts;
using Churrascaria.Repository;
using Churrascaria.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Churrascaria.IoC
{
    public static class DependenceResolve
    {
        public static void Resolve(this IServiceCollection services)
        {
            services.AddSingleton<Configuration>();
            services.AddDbContext<ChurrascariaContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFuncionarioAppService, FuncionarioAppService>();
            services.AddScoped<IConvidadoAppService, ConvidadoAppService>();
            services.AddScoped<IParticipanteAppService, ParticipanteAppService>();
       
            services.AddScoped<IConvidadoRepository, ConvidadoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IParticipanteRepository, ParticipanteRepository>();
        }
    }
}
