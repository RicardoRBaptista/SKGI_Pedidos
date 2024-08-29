namespace SKGI_Pedidos.Models
{
    public class MovimentacaoProdutos
    {
        public string? Codigo { get; set; }
        public string? Produto { get; set; }
        public string? Lote { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }

        public MovimentacaoProdutos() { }
    }
}
