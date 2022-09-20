using Exercicio02.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Exercicio02.Interfaces
{
    public interface ITbUsuarioRepository : IBaseRepository<TbUsuario>
    {
        public ICollection<TbUsuario> ListarTodosUsuariosComEventos();
        public ICollection<TbUsuario> ListarPorIdUsuarioComEventos(int id);
    }
}
