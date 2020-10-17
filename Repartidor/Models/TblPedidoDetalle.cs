using System;
using System.Collections.Generic;

namespace Repartidor.Models
{
    public partial class TblPedidoDetalle
    {
        public int IdPedidoDetalle { get; set; }
        public int? CantidadPedidoDetalle { get; set; }
        public double PrecioPedidoDetalle { get; set; }
        public double TotalPedidoDetalle { get; set; }
        public bool? ActivoPedidoDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }

        public virtual TblPedido IdPedidoNavigation { get; set; }
        public virtual TblProducto IdProductoNavigation { get; set; }
    }
}
