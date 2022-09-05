using System;
using System.Collections.Generic;

#nullable disable

namespace Exercicio02.Models
{
    public partial class TbEvento
    {
        public TbEvento()
        {
            RlUsuarioEventos = new HashSet<RlUsuarioEvento>();
        }

        public int Id { get; set; }
        public DateTime? DataHora { get; set; }
        public bool? Ativo { get; set; }
        public decimal? Preco { get; set; }
        public int? CategoriaId { get; set; }

        public virtual TbCategoria Categoria { get; set; }
        public virtual ICollection<RlUsuarioEvento> RlUsuarioEventos { get; set; }
    }
}
