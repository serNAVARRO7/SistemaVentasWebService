using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaVentas.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Concepto = new HashSet<Concepto>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? Total { get; set; }
        public long IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Concepto> Concepto { get; set; }
    }
}
