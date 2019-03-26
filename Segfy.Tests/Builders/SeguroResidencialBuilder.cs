using Segfy.Domain.Entities;

namespace Segfy.Tests.Builders
{
    public class SeguroResidencialBuilder
    {
        private Cliente cliente;
        private decimal valor;
        private Endereco enderecoDeRisco;

        public SeguroResidencialBuilder()
        {
            cliente = new ClienteBuilder().Builder();
            valor = 1000;
            enderecoDeRisco = new EnderecoBuilder().Builder();
        }

        public SeguroResidencial Builder() => new SeguroResidencial(cliente, enderecoDeRisco, valor);

        public SeguroResidencialBuilder ComCliente(Cliente cliente)
        {
            this.cliente = cliente;
            return this;
        }

        public SeguroResidencialBuilder ComValor(decimal valor)
        {
            this.valor = valor;
            return this;
        }

        public SeguroResidencialBuilder ComEnderecoDeRisco(Endereco enderecoDeRisco)
        {
            this.enderecoDeRisco = enderecoDeRisco;
            return this;
        }
    }
}
