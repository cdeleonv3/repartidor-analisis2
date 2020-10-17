using System;
using System.Collections.Generic;

namespace Repartidor.Models
{
    public partial class TblMarca
    {
        public TblMarca()
        {
            TblProducto = new HashSet<TblProducto>();
        }

        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public string DescripcionMarca { get; set; }
        public bool? ActivoMarca { get; set; }

        public virtual ICollection<TblProducto> TblProducto { get; set; }
    }
}
