using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TallerMecanica.Models;

namespace TallerMecanica
{
    public class Singleton
    {
        public static Cliente cliente_login = new Cliente()
        {
            isAdmin = true,
            nombreCompleto = "Ronaldd ris0",
            email = "retejada@alu.ucam.edu",
            contrasena = "1234",
            idCliente = 1,
            telefono1 = "747654894"
        };
    }
}
