using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.ApplicationCore.Interfaces.Services
{
    public interface INobreakEventService
    {
        NobreakEvent Adicionar(NobreakEvent entity);
        void Atualizar(NobreakEvent entity);
        IEnumerable<NobreakEvent> ObterTodos();
        NobreakEvent ObterPorId(int Id);
        IEnumerable<NobreakEvent> Buscar(Expression<Func<NobreakEvent, bool>> predicado);
        void Remover(NobreakEvent entity);
    }
}
