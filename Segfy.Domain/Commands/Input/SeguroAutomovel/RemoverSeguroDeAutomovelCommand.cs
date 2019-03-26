using Flunt.Notifications;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Input.SeguroAutomovel
{
    public class RemoverSeguroDeAutomovelCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        bool ICommand.Valid() => true;
    }
}
