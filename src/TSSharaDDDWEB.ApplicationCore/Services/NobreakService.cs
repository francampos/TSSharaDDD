using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TSSharaDDDWEB.ApplicationCore.Entity;
using TSSharaDDDWEB.ApplicationCore.Interfaces.Repository;
using TSSharaDDDWEB.ApplicationCore.Interfaces.Services;

namespace TSSharaDDDWEB.ApplicationCore.Services
{
    public class NobreakService : INobreakService
    {
        private readonly INobreakRepository _nobreakRepository;

        public NobreakService(INobreakRepository nobreakRepository)
        {
            _nobreakRepository = nobreakRepository;
        }

        public Nobreak Adicionar(Nobreak entity)
        {
            //Regras de negócio adicionada aqui
            return _nobreakRepository.Adicionar(entity);
        }

        public void Atualizar(Nobreak entity)
        {
            _nobreakRepository.Atualizar(entity);
        }

        public IEnumerable<Nobreak> Buscar(Expression<Func<Nobreak, bool>> predicado)
        {
            return _nobreakRepository.Buscar(predicado);
        }

        public Nobreak ObterPorId(int id)
        {
            return _nobreakRepository.ObterPorId(id);
        }

        public IEnumerable<Nobreak> ObterTodos()
        {
            return _nobreakRepository.ObterTodos();
        }

        public void Remover(Nobreak entity)
        {
            _nobreakRepository.Remover(entity);
        }
    }
}
