using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentas.Models.Request
{
    public class VentaRequest
    {
        public long IdCliente { get; set; }
        public decimal Total { get; set; }

        public List<Concepto> Conceptos { get; set; }

        public VentaRequest()
        {
            this.Conceptos = new List<Concepto>();
        }
    }

    public class Concepto
    {
        public long IdProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Importe { get; set; }
    }
}
