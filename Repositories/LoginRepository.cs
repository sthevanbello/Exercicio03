using Exercicio02.Data;
using Exercicio02.Interfaces;
using Exercicio02.Models;
using System.Linq;

namespace Exercicio02.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly Mais_EventosContext _ctx;

        public LoginRepository(Mais_EventosContext ctx)
        {
            _ctx = ctx;
        }

        public TbUsuario Logar(string email, string senha)
        {
            var usuario = _ctx.TbUsuarios.Where(u => u.Email == email).FirstOrDefault();
            if (usuario != null)
            {
                bool validPassword = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
                if (validPassword)
                    return usuario;
            }
            return null;
        }
    }
}
