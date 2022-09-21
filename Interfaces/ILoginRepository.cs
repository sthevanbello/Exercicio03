using Exercicio02.Models;

namespace Exercicio02.Interfaces
{
    public interface ILoginRepository
    {
        string Logar(string email, string senha);
    }
}
