using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentas.Models.Response
{
    public class UserResponse
    {
        public string Email { get; set; }
        public object Token { get; set; }
    }
}
