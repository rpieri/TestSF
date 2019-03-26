using Flunt.Notifications;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Input.SeguroDeVida
{
    public class RemoverSeguroDeVidaCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        bool ICommand.Valid() => true;
    }
}
