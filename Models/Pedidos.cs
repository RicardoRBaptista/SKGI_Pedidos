using System.Security.Claims;

namespace SKGI_Pedidos.Models
{
    public class Pedidos
    {
        public Pedidos(string pedido, DateTime emissao, string status, int nF, DateTime coleta, string transportadora)
        {
            Pedido = pedido;
            Emissao = emissao;
            Status = status;
            NF = nF;
            Coleta = coleta;
            Transportadora = transportadora;
        }

        public string Pedido { get; set; }
        public DateTime Emissao { get; set; }
        public string Status { get; set; }
        public int NF { get; set; }
        public DateTime Coleta { get; set; }
        public string Transportadora { get; set; }
    }
}
