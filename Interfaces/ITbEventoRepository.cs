using Exercicio02.Models;
using Exercicio02.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Exercicio02.Interfaces
{
    public interface ITbEventoRepository 
    {
        public TbEvento Inserir(TbEvento item);
        public ICollection<TbEvento> ListarTodos();
        public TbEvento BuscarPorId(int id);
        public void Alterar(TbEvento item);
        public void AlterarParcialmente(JsonPatchDocument patchItem, TbEvento item);
    }
}
