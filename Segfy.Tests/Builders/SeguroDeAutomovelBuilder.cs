using Segfy.Domain.Entities;

namespace Segfy.Tests.Builders
{
    public class SeguroDeAutomovelBuilder
    {
        private Cliente cliente;
        private decimal valor;
        private string placa;

        public SeguroDeAutomovelBuilder()
        {
            cliente = new ClienteBuilder().Builder();
            valor = 1000;
            placa = "AOI-7898";
        }

        public SeguroDeAutomovel Builder() => new SeguroDeAutomovel(cliente, placa, valor);

        public SeguroDeAutomovelBuilder ComCliente(Cliente cliente)
        {
            this.cliente = cliente;
            return this;
        }

        public SeguroDeAutomovelBuilder ComValor(decimal valor)
        {
            this.valor = valor;
            return this;
        }

        public SeguroDeAutomovelBuilder ComPlaca(string placa)
        {
            this.placa = placa;
            return this;
        }
    }
}
