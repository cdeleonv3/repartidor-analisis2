using System;
using System.Collections.Generic;

namespace Repartidor2.Models
{
    public partial class TblTipoEmpleado
    {
        public TblTipoEmpleado()
        {
            TblEmpleado = new HashSet<TblEmpleado>();
        }

        public int IdTipoEmpleado { get; set; }
        public string NombreTipoEmpleado { get; set; }
        public string DescripcionTipoEmpleado { get; set; }
        public bool? ActivoTipoEmpleado { get; set; }

        public virtual ICollection<TblEmpleado> TblEmpleado { get; set; }
    }
}
