using System;
using System.Collections.Generic;

namespace Repartidor.Models
{
    public partial class TblPedido
    {
        public TblPedido()
        {
            TblPedidoDetalle = new HashSet<TblPedidoDetalle>();
        }

        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public TimeSpan HoraPedido { get; set; }
        public TimeSpan HoraEntrega { get; set; }
        public string DireccionPedido { get; set; }
        public string DetalleDireccion { get; set; }
        public double Total { get; set; }
        public bool? ActivoPedido { get; set; }
        public int IdTarjeta { get; set; }
        public int IdCliente { get; set; }
        public int IdRestaurante { get; set; }
        public int IdEstado { get; set; }

        public virtual TblTarjeta Id { get; set; }
        public virtual TblEstado IdEstadoNavigation { get; set; }
        public virtual TblRestaurante IdRestauranteNavigation { get; set; }
        public virtual ICollection<TblPedidoDetalle> TblPedidoDetalle { get; set; }
    }
}
