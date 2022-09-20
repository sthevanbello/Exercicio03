using System;
using System.Collections.Generic;

#nullable disable

namespace Exercicio02.Models
{
    public partial class RlUsuarioEvento
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? EventoId { get; set; }
        public virtual TbEvento Evento { get; set; }
        public virtual TbUsuario Usuario { get; set; }
    }
}
