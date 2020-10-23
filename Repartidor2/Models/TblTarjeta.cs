using System;
using System.Collections.Generic;

namespace Repartidor2.Models
{
    public partial class TblTarjeta
    {
        public TblTarjeta()
        {
            TblPedido = new HashSet<TblPedido>();
        }

        public int IdTarjeta { get; set; }
        public int IdCliente { get; set; }
        public string NombreTarjeta { get; set; }
        public int NumeroTarjeta { get; set; }
        public DateTime FechaVenceTarjeta { get; set; }
        public string ProveedorTarjeta { get; set; }
        public int? CvvTarjeta { get; set; }
        public bool? ActivoTarjeta { get; set; }

        public virtual TblCliente IdClienteNavigation { get; set; }
        public virtual ICollection<TblPedido> TblPedido { get; set; }
    }
}
