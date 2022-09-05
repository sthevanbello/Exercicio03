using Exercicio02.Data;
using Exercicio02.Interfaces;
using Exercicio02.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Exercicio02.Repositories
{

    public class TbCategoriaRepository : ITbCategoriaRepository
    {
        private readonly IBaseRepository<TbCategoria> _baseRepository;


        public TbCategoriaRepository(IBaseRepository<TbCategoria> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Alterar(TbCategoria item)
        {
            _baseRepository.Alterar(item);
        }

        public void AlterarParcialmente(JsonPatchDocument patchItem, TbCategoria item)
        {
            _baseRepository.AlterarParcialmente(patchItem, item);
        }

        public TbCategoria BuscarPorId(int id)
        {
            return _baseRepository.BuscarPorId(id);
        }

        public TbCategoria Inserir(TbCategoria item)
        {

            return _baseRepository.Inserir(item);
        }

        public ICollection<TbCategoria> ListarTodos()
        {
            return _baseRepository.ListarTodos();
        }
    }
}
