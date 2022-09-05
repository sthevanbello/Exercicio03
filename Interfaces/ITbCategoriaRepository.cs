using Exercicio02.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Exercicio02.Interfaces
{
    public interface ITbCategoriaRepository
    {
        public TbCategoria Inserir(TbCategoria item);
        public ICollection<TbCategoria> ListarTodos();
        public TbCategoria BuscarPorId(int id);
        public void Alterar(TbCategoria item);
        public void AlterarParcialmente(JsonPatchDocument patchItem, TbCategoria item);
    }
}
