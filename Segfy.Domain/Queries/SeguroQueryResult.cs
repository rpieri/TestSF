namespace Segfy.Domain.Queries
{
    public class SeguroQueryResult
    {
        public int Id { get; set; }
        public int TipoSeguro { get; set; }
        public string TipoSeguroString { get; set; }
        public string Cliente { get; set; }
        public string CPFCliente { get; set; }
        public string Placa { get; set; }
        public string EnderecoDeRisco { get; set; }
        public string CPFDoSegurado { get; set; }
        public decimal Valor { get; set; }
    }
}
