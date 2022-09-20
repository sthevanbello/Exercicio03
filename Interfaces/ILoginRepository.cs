using Exercicio02.Models;

namespace Exercicio02.Interfaces
{
    public interface ILoginRepository
    {
        TbUsuario Logar(string email, string senha);
    }
}
