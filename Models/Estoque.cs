namespace SKGI_Pedidos.Models
{
    public class Estoque
    {
        public Estoque()
        {
        }

        public Estoque(string codigo, string nome, int saldoEstoque, int empenhada, int quarentena, int naoConforme, int estoqueFinal)
        {
            this.codigo = codigo;
            Nome = nome;
            SaldoEstoque = saldoEstoque;
            Empenhada = empenhada;
            Quarentena = quarentena;
            NaoConforme = naoConforme;
            EstoqueFinal = estoqueFinal;
        }

        public string? codigo { get; set; }
        public string? Nome { get; set; }
        public int SaldoEstoque { get; set; }
        public int Empenhada { get; set; }
        public int Quarentena { get; set; }
        public int NaoConforme { get; set; }
        public int EstoqueFinal { get; set; }
    }    
}
