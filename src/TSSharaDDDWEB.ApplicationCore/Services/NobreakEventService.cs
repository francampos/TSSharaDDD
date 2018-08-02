using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TSSharaDDDWEB.ApplicationCore.Entity;
using TSSharaDDDWEB.ApplicationCore.Interfaces.Repository;
using TSSharaDDDWEB.ApplicationCore.Interfaces.Services;

namespace TSSharaDDDWEB.ApplicationCore.Services
{
    public class NobreakEventService : INobreakEventService
    {
        private readonly INobreakEventRepository _nobreakEventRepository;

        public NobreakEventService(INobreakEventRepository nobreakEventRepository)
        {
            _nobreakEventRepository = nobreakEventRepository;
        }

        public NobreakEvent Adicionar(NobreakEvent entity)
        {
            //Regras de negócio adicionada aqui
            return _nobreakEventRepository.Adicionar(entity);
        }

        public void Atualizar(NobreakEvent entity)
        {
            _nobreakEventRepository.Atualizar(entity);
        }

        public IEnumerable<NobreakEvent> Buscar(Expression<Func<NobreakEvent, bool>> predicado)
        {
            return _nobreakEventRepository.Buscar(predicado);
        }

        public NobreakEvent ObterPorId(int id)
        {
            return _nobreakEventRepository.ObterPorId(id);
        }

        public IEnumerable<NobreakEvent> ObterTodos()
        {
            return _nobreakEventRepository.ObterTodos();
        }

        public void Remover(NobreakEvent entity)
        {
            _nobreakEventRepository.Remover(entity);
        }
    }
}
