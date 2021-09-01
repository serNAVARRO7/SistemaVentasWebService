using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SistemaVentas.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Concepto = new HashSet<Concepto>();
        }

        public long Id { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Costo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Concepto> Concepto { get; set; }
    }
}
