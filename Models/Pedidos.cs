namespace SKGI_Pedidos.Models
{
    public class Pedidos
    {
        public Pedidos()
        {

        }

        public Pedidos(int numero, DateTime emissao, string status, int qtdTotal, int nF, DateTime coleta, string cliente, string transportadora, string oBS)
        {
            Numero = numero;
            Emissao = emissao;
            Status = status;
            QtdTotal = qtdTotal;
            NF = nF;
            Coleta = coleta;
            Cliente = cliente;
            Transportadora = transportadora;
            OBS = oBS;
        }

        public int Numero { get; set; }
        public DateTime Emissao { get; set; }
        public string? Status { get; set; }
        public int QtdTotal { get; set; }
        public int NF { get; set; }
        public DateTime Coleta { get; set; }
        public string? Cliente { get; set; }
        public string? Transportadora { get; set; }
        public string? OBS { get; set; }
    }
}
