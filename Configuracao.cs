using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKGI_Pedidos
{
    public sealed class Configuracao
    {
        public static string ConnectionString { get; set; }
        public static string LoginBD { get; set; }
        public static string SenhaBD { get; set; }
    }
}
