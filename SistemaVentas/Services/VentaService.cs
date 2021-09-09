using SistemaVentas.Models;
using SistemaVentas.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentas.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest oModel)
        {
            using (SistemaVentasContext db = new SistemaVentasContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Venta oVenta = new Venta();
                        oVenta.Total = oModel.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                        oVenta.Fecha = DateTime.Now;
                        oVenta.IdCliente = oModel.IdCliente;
                        db.Venta.Add(oVenta);
                        db.SaveChanges();
                        // En este momento Entity Framework genera un id para la venta
                        foreach (var concepto in oModel.Conceptos)
                        {
                            Models.Concepto oConcepto = new Models.Concepto();
                            oConcepto.Cantidad = concepto.Cantidad;
                            oConcepto.IdProducto = concepto.IdProducto;
                            oConcepto.Importe = concepto.Importe;
                            oConcepto.PrecioUnitario = concepto.PrecioUnitario;
                            oConcepto.IdVenta = oVenta.Id;
                            db.Concepto.Add(oConcepto);
                            db.SaveChanges();
                        }
                        // La transaccion bloquea las tablas por lo que es necesario indicar que la transaccion ha finalizado
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Error durante la insercion");
                    }
                }
            }
        }
    }
}
