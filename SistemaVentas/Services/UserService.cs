using SistemaVentas.Models.Request;
using SistemaVentas.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVentas.Models;
using SistemaVentas.Models.Response;
using SistemaVentas.Models.Request;
using SistemaVentas.Models.ViewModels;
using SistemaVentas.Tools;

namespace SistemaVentas.Services
{
    public class UserService : IUserService
    {
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse(); ;
            using (SistemaVentasContext db = new SistemaVentasContext())
            {
                // Encripto la contraseña a SHA256 tal y como se guardan en BD
                string spassword = Encrypt.GetSHA256(model.Password);
                var usuario = db.Usuario.Where(d => d.Email == model.Email && d.Password == spassword)
                    .FirstOrDefault();
                if (usuario == null) return null;
                userResponse.Email = usuario.Email;
            }
            return userResponse;
        }
    }
}
