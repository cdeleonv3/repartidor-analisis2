using System;
using System.Collections.Generic;

namespace Repartidor.Models
{
    public partial class TblProducto
    {
        public TblProducto()
        {
            TblPedidoDetalle = new HashSet<TblPedidoDetalle>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool? ActivoProducto { get; set; }
        public int? IdMarca { get; set; }
        public int? IdTipoProducto { get; set; }

        public virtual TblMarca IdMarcaNavigation { get; set; }
        public virtual TblTipoProducto IdTipoProductoNavigation { get; set; }
        public virtual ICollection<TblPedidoDetalle> TblPedidoDetalle { get; set; }
    }
}
