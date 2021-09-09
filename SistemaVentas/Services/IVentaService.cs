using SistemaVentas.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentas.Services
{
    public interface IVentaService
    {
        public void Add(VentaRequest oModel);
    }
}
