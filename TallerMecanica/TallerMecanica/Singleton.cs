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
        public static Cliente cliente_login { get; set; }

        public static List<MateriaPrima_ProductoComprado> MaterialesComprados { get; set; }
    }
}
