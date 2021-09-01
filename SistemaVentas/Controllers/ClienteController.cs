using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVentas.Models;

namespace SistemaVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() 
        {
            using (SistemaVentasContext db = new SistemaVentasContext())
            {
                var lst = db.Cliente.ToList();
                return Ok(lst);
            }
        }
    }
}
