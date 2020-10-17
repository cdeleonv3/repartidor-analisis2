using System;
using System.Collections.Generic;

namespace Repartidor.Models
{
    public partial class TblTipoProducto
    {
        public TblTipoProducto()
        {
            TblProducto = new HashSet<TblProducto>();
        }

        public int IdTipoProducto { get; set; }
        public string NombreTipoProducto { get; set; }
        public string DescripcionTipoProducto { get; set; }
        public bool? ActivoTipoProducto { get; set; }

        public virtual ICollection<TblProducto> TblProducto { get; set; }
    }
}
