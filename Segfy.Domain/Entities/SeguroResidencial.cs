using Flunt.Validations;

namespace Segfy.Domain.Entities
{
    public class SeguroResidencial : Seguro
    {
        public SeguroResidencial(Cliente cliente, Endereco enderecoDeRisco,decimal valor) : base(cliente, valor)
        {
            EnderecoDeRisco = enderecoDeRisco;
            AddNotifications(new Contract()
                .IsNotNull(EnderecoDeRisco, "Endereço de risco", "Endereço de risco deve ser informado"));
        }

        public Endereco EnderecoDeRisco { get; private set; }

        protected SeguroResidencial()
        {

        }
        public void Alterar(Endereco enderecoDeRisco, decimal valor)
        {
            Alterar(enderecoDeRisco);
            Alterar(valor);
        }

        private void Alterar(Endereco enderecoDeRisco)
        {
            EnderecoDeRisco = enderecoDeRisco;
            AddNotifications(new Contract()
                .IsNotNull(EnderecoDeRisco, "Endereço de risco", "Endereço de risco deve ser informado"));
        }
    }
}
