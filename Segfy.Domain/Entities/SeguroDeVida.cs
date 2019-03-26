using Flunt.Validations;

namespace Segfy.Domain.Entities
{
    public class SeguroDeVida : Seguro
    {
        public SeguroDeVida(Cliente cliente, string cpf, decimal valor) : base(cliente, valor)
        {
            AlterarCpf(cpf);
        }
        public string CPF { get; private set; }

        protected SeguroDeVida()
        {

        }

        public void Alterar(string cpf, decimal valor)
        {
            AlterarCpf(cpf);
            Alterar(valor);
        }

        private void AlterarCpf(string cpf)
        {
            CPF = cpf;
            AddNotifications(new Contract()
                .HasMaxLen(CPF, 12, "CPF", "CPF deve conter ate 12 caracteres")
                .HasMinLen(CPF, 5, "CPF", "CPF deve conter acima de 5 caracteres")
                .IsNullOrEmpty(CPF, "CPF", "CPF deve ser informado"));
        }
    }
}
