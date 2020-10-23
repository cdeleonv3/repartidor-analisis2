using System;
using System.Collections.Generic;

namespace Repartidor2.Models
{
    public partial class TblEmpleado
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TelefonoEmpleado { get; set; }
        public string DireccionEmpleado { get; set; }
        public bool? ActivoEmpleado { get; set; }
        public int IdRestaurante { get; set; }
        public int IdTipoEmpleado { get; set; }

        public virtual TblRestaurante IdRestauranteNavigation { get; set; }
        public virtual TblTipoEmpleado IdTipoEmpleadoNavigation { get; set; }
    }
}
