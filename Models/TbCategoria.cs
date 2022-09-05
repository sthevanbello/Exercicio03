using System;
using System.Collections.Generic;

#nullable disable

namespace Exercicio02.Models
{
    public partial class TbCategoria
    {
        public TbCategoria()
        {
            TbEventos = new HashSet<TbEvento>();
        }

        public int Id { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<TbEvento> TbEventos { get; set; }
    }
}
