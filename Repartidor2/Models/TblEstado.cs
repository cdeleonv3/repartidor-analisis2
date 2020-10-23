using System;
using System.Collections.Generic;

namespace Repartidor2.Models
{
    public partial class TblEstado
    {
        public TblEstado()
        {
            TblPedido = new HashSet<TblPedido>();
        }

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public string DescripcionEstado { get; set; }
        public bool? ActivoEstado { get; set; }

        public virtual ICollection<TblPedido> TblPedido { get; set; }
    }
}
