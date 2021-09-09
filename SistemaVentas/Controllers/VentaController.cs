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
using SistemaVentas.Services;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private IVentaService _venta;
        public VentaController(VentaService venta)
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                _venta.Add(oModel);
                oRespuesta.Exito = 1;
            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
