using System;
using System.Collections.Generic;

namespace Repartidor2.Models
{
    public partial class TblRestaurante
    {
        public TblRestaurante()
        {
            TblEmpleado = new HashSet<TblEmpleado>();
            TblPedido = new HashSet<TblPedido>();
        }

        public int IdRestaurante { get; set; }
        public string NombreRestaurante { get; set; }
        public string DireccionRestaurante { get; set; }
        public int Telefono { get; set; }
        public bool? ActivoRestaurante { get; set; }

        public virtual ICollection<TblEmpleado> TblEmpleado { get; set; }
        public virtual ICollection<TblPedido> TblPedido { get; set; }
    }
}
