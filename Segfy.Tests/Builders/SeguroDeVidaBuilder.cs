using Segfy.Domain.Entities;

namespace Segfy.Tests.Builders
{
    public class SeguroDeVidaBuilder
    {
        private Cliente cliente;
        private decimal valor;
        private string cpf;

        public SeguroDeVidaBuilder()
        {
            cliente = new ClienteBuilder().Builder();
            valor = 1000;
            cpf = "01236545699";
        }

        public SeguroDeVida Builder() => new SeguroDeVida(cliente, cpf, valor);

        public SeguroDeVidaBuilder ComCliente(Cliente cliente)
        {
            this.cliente = cliente;
            return this;
        }

        public SeguroDeVidaBuilder ComValor(decimal valor)
        {
            this.valor = valor;
            return this;
        }

        public SeguroDeVidaBuilder ComCpf(string cpf)
        {
            this.cpf = cpf;
            return this;
        }
    }
}
