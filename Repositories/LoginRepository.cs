using Exercicio02.Data;
using Exercicio02.Interfaces;
using Exercicio02.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Exercicio02.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly Mais_EventosContext _ctx;

        public LoginRepository(Mais_EventosContext ctx)
        {
            _ctx = ctx;
        }

        public string Logar(string email, string senha)
        {
            var usuario = _ctx.TbUsuarios.Where(u => u.Email == email).FirstOrDefault();
            if (usuario != null)
            {
                bool validPassword = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
                if (validPassword)
                {
                    // Criar as credenciais do JWT

                    // Definições das Claims
                    var minhasClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role, "Adm"),
                        new Claim("Cargo", "Adm")

                    };
                    // Criada a chave de criptografia
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cripto-chave-autenticacao"));

                    // Criar as credenciais
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Gerar o token (objeto)
                    var token = new JwtSecurityToken(
                        issuer: "cripto.webAPI",
                        audience: "cripto.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                        );
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }
            return null;
        }
    }
}
