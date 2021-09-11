using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentas.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Valor de id incorrecto")]
        [ExisteClienteAttributeValidation(ErrorMessage = "El cliente no existe")]
        public long IdCliente { get; set; }
        public decimal Total { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Es necesario al menos un concepto")]
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

    #region Validaciones
    public class ExisteClienteAttributeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int idCliente = (int)value;
            using (SistemaVentasContext db = new SistemaVentasContext())
            {
                try
                {
                    if (db.Cliente.Find(idCliente) == null) return false;
                }
                catch (Exception e)
                {
                    throw new Exception("Error durante la validacion del modelo con la BD");
                }
            }
            return true;
        }
    }
    #endregion
}
