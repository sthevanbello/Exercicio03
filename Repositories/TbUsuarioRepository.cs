using Exercicio02.Data;
using Exercicio02.Interfaces;
using Exercicio02.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio02.Repositories
{
    public class TbUsuarioRepository : BaseRepository<TbUsuario>,ITbUsuarioRepository
    {
        private readonly Mais_EventosContext _context;

        public TbUsuarioRepository(Mais_EventosContext context) : base(context)
        {
            _context = context;
        }


        public ICollection<TbUsuario> ListarTodosUsuariosComEventos()
        {
            var usuarios = _context.TbUsuarios
                .Include(u => u.RlUsuarioEventos)
                .ThenInclude(e => e.Evento)
                .ThenInclude(c => c.Categoria)
                .ToList();
            
            return usuarios;
        }
    }
}
