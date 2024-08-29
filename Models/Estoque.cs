using System.Reflection.Metadata.Ecma335;

namespace SKGI_Pedidos.Models
{
    public class Estoque
    {
        public Estoque()
        {
        }

        public Estoque(string codigo, string nome, int saldoEstoque, int empenhada, int quarentena, int naoConforme, int estoqueFinal)
        {
            Codigo = codigo;
            Nome = nome;
            SaldoEstoque = saldoEstoque;
            Empenhada = empenhada;
            Quarentena = quarentena;
            NaoConforme = naoConforme;
            EstoqueFinal = estoqueFinal;
            QuantidadeRetirada = 0;
        }

        public string? Codigo { get; set; }
        public string? Nome { get; set; }
        public int SaldoEstoque { get; set; }
        public int Empenhada { get; set; }
        public int Quarentena { get; set; }
        public int NaoConforme { get; set; }
        public int EstoqueFinal { get; set; }
        public int QuantidadeRetirada { get; set; } // Nova propriedade

        public static List<Estoque> carregaEstoque()
        {
            List<Estoque> estoques = new List<Estoque>
                {
                new Estoque { Codigo = "IM001CHN0052", Nome = "MACARRAO SWEET POTATO VERMICELLE 400GX30", SaldoEstoque = 240, Empenhada = 0, Quarentena = 0, NaoConforme = 0, EstoqueFinal = 240 },
                new Estoque { Codigo = "IM001CHN0500", Nome = "ALGAS HIJIKI 40GX100/CTN", SaldoEstoque = 150, Empenhada = 0, Quarentena = 0, NaoConforme = 0, EstoqueFinal = 150 },
                new Estoque { Codigo = "IM001THA0107", Nome = "GELATINAS AGAR PO AG DESS MIX ALM FL 120/130G", SaldoEstoque = 19, Empenhada = 0, Quarentena = 0, NaoConforme = 0, EstoqueFinal = 19 },
                new Estoque { Codigo = "IM001THA0833", Nome = "LEITE COCO COCONUT MILK 17-19%FAT 24X400ML", SaldoEstoque = 150, Empenhada = 0, Quarentena = 0, NaoConforme = 0, EstoqueFinal = 150 },
                new Estoque { Codigo = "IM001TWN0323", Nome = "MASSAS ARROZ RICE PAPER 22CM 340GX50", SaldoEstoque = 715, Empenhada = 0, Quarentena = 0, NaoConforme = 0, EstoqueFinal = 715 },
                // Adicione os outros itens aqui...
                };
        
            return estoques;
        }
    }
}
