using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVentas.Models;
using SistemaVentas.Models.Response;
using SistemaVentas.Models.Request;
using SistemaVentas.Models.ViewModels;

namespace SistemaVentas.Services
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
    }
}
