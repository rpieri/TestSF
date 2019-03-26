using Flunt.Notifications;
using Flunt.Validations;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Input.SeguroDeVida
{
    public class AlterarSeguroDeVidaCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public string CPF { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new Contract()
                    .HasMaxLen(CPF, 12, "CPF", "CPF deve conter ate 12 caracteres")
                    .HasMinLen(CPF, 5, "CPF", "CPF deve conter acima de 5 caracteres")
                    .IsNullOrEmpty(CPF, "CPF", "CPF deve ser informado")
                    .IsGreaterThan(ClienteId, 0, "Cliente", "O cliente deve ser maior que 0")
                    .IsGreaterThan(Valor, 0, "Valor", "O valor do seguro deve ser maior que 0"));

            return Valid;

        }
    }
}
