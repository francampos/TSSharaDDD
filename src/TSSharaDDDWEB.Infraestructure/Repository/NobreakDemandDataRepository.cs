using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TSSharaDDDWEB.ApplicationCore.Entity;
using TSSharaDDDWEB.ApplicationCore.Interfaces.Repository;

namespace TSSharaDDDWEB.Infraestructure.Repository
{
    public class NobreakDemandDataRepository : IRepository<NobreakDemandData>, INobreakDemandDataRepository
    {
        public NobreakDemandData Adicionar(NobreakDemandData entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(NobreakDemandData entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NobreakDemandData> Buscar(Expression<Func<NobreakDemandData, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public NobreakDemandData ObterPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NobreakDemandData> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(NobreakDemandData entity)
        {
            throw new NotImplementedException();
        }
    }
}
