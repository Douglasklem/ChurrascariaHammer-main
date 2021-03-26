using Churrascaria.AppService.Contracts;
using Churrascaria.Domain.Contracts;
using Churrascaria.UoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Churrascaria.AppService
{
    public class AppService<TEntity> : IAppService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;
        private readonly IUnitOfWork unitOfWork;

        public AppService(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public virtual async Task Alterar(TEntity entity)
        {
            try
            {
                await repository.Alterar(entity);
                await unitOfWork.Commit();
            }
            catch
            {
                await unitOfWork.RollBack();
            }
        }

        public virtual async Task Deletar(int Id)
        {
            try
            {
                await repository.Deletar(Id);
                await unitOfWork.Commit();
            }
            catch
            {
                await unitOfWork.RollBack();
            }
        }

        public virtual async Task Gravar(TEntity entity)
        {
            try
            {
                await repository.Gravar(entity);
                await unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                await unitOfWork.RollBack();
            }
        }

        public virtual async Task<ICollection<TEntity>> Listar()
        {
            return await repository.Listar();
        }

    }
}
