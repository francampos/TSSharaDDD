using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TSSharaDDDWEB.ApplicationCore.Entity;

namespace TSSharaDDDWEB.ApplicationCore.Interfaces.Services
{
    public interface INobreakService
    {
        Nobreak Adicionar(Nobreak entity);
        void Atualizar(Nobreak entity);
        IEnumerable<Nobreak> ObterTodos();
        Nobreak ObterPorId(int Id);
        IEnumerable<Nobreak> Buscar(Expression<Func<Nobreak, bool>> predicado);
        void Remover(Nobreak entity);
    }
}
