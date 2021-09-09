using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVentas.Models;
using SistemaVentas.Models.Response;
using SistemaVentas.Models.Request;
using SistemaVentas.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Add(VentaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
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
                            oRespuesta.Exito = 1;
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
