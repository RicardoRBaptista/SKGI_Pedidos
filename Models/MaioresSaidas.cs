namespace SKGI_Pedidos.Models
{
    public class MaioresSaidas
    {
        public int CodCliente { get; set; }
        public string? Nome { get; set; }
        public string? Produto { get; set; }
        public string? Descricao { get; set; }
        public decimal Quantidade { get; set; }

        public MaioresSaidas()
        {
        }
    }

}
