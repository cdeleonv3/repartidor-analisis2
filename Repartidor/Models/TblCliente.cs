using System;
using System.Collections.Generic;

namespace Repartidor.Models
{
    public partial class TblCliente
    {
        public TblCliente()
        {
            TblTarjeta = new HashSet<TblTarjeta>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string EmailCliente { get; set; }
        public int? TelefonoCliente { get; set; }

        public virtual ICollection<TblTarjeta> TblTarjeta { get; set; }
    }
}
