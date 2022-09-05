using Exercicio02.Data;
using Exercicio02.Interfaces;
using Exercicio02.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio02.Repositories
{
    public class TbEventoRepository : ITbEventoRepository 
    {
        private readonly IBaseRepository<TbEvento> _baseRepository;

        public TbEventoRepository(IBaseRepository<TbEvento> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Alterar(TbEvento evento)
        {
            _baseRepository.Alterar(evento);
        }

        public void AlterarParcialmente(JsonPatchDocument patchEvento, TbEvento evento)
        {
            _baseRepository.AlterarParcialmente(patchEvento, evento);
        }

        public TbEvento BuscarPorId(int id)
        {
            return _baseRepository.BuscarPorId(id);
        }

        public TbEvento Inserir(TbEvento evento)
        {
            return _baseRepository.Inserir(evento);
        }

        public ICollection<TbEvento> ListarTodos()
        {
            var eventos = _baseRepository.ListarTodos();
            return eventos;
        }
    }
}
