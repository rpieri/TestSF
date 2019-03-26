using Flunt.Notifications;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Input.Clientes
{
    public class RemoverClienteCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        bool ICommand.Valid() => true;
    }
}
