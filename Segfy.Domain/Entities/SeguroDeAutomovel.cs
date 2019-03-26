using Flunt.Validations;

namespace Segfy.Domain.Entities
{
    public class SeguroDeAutomovel : Seguro
    {
        public SeguroDeAutomovel(Cliente cliente, string placa, decimal valor) : base(cliente, valor)
        {
            Alterar(placa);
        }

        public string Placa { get; private set; }

        protected SeguroDeAutomovel()
        {

        }

        public void Alterar(string placa, decimal valor)
        {
            Alterar(placa);
            Alterar(valor);
        }

        private void Alterar(string placa)
        {
            Placa = placa;
            AddNotifications(new Contract()
                .HasMaxLen(Placa, 20, "Placa do automovel", "A placa do automovel deve conter ate 20 caracteres")
                .HasMinLen(Placa, 5, "Placa do automovel", "A placa do automovel deve conter acima de 5 caracteres")
                .IsNullOrEmpty(Placa, "Placa do automovel", "A placa do automovel deve ser informada"));
        }

    }
}
