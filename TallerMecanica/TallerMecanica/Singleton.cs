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
        //sigleton.clientelogin =
        public static Cliente cliente_login;

        public static List<MateriaPrima_ProductoComprado> itemsCompra = new List<MateriaPrima_ProductoComprado>();
    }
}
