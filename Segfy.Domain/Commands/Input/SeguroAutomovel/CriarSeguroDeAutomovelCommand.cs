using Flunt.Notifications;
using Flunt.Validations;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Input.SeguroAutomovel
{
    public class CriarSeguroDeAutomovelCommand : Notifiable, ICommand
    {
        public int ClienteId { get; set; }
        public string Placa { get; set; }
        public decimal Valor { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new Contract()
                .HasMaxLen(Placa, 20, "Placa do automovel", "A placa do automovel deve conter ate 20 caracteres")
                .HasMinLen(Placa, 5, "Placa do automovel", "A placa do automovel deve conter acima de 5 caracteres")
                .IsNullOrEmpty(Placa, "Placa do automovel", "A placa do automovel deve ser informada")
                .IsGreaterThan(Valor, 0, "Valor", "O valor do seguro deve ser maior que 0"));

            return Valid;
        }
    }
}
