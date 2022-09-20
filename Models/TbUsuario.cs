using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Exercicio02.Models
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            RlUsuarioEventos = new HashSet<RlUsuarioEvento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Imagem { get; set; }
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<RlUsuarioEvento> RlUsuarioEventos { get; set; }
    }
}
