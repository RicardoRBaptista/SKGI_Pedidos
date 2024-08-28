using System.Security.Claims;

namespace SKGI_Pedidos.Models
{
    public class Pedidos
    {
        public Pedidos(string pedido, DateTime emissao, string status, int nF, DateTime date, string transportadora)
        {
            Pedido = pedido;
            Emissao = emissao;
            Status = status;
            NF = nF;
            this.date = date;
            Transportadora = transportadora;
        }

        public string Pedido { get; set; }
        public DateTime Emissao { get; set; }
        public string Status { get; set; }
        public int NF { get; set; }
        public DateTime date { get; set; }
        public string Transportadora { get; set; }
    }
}
