using Flunt.Notifications;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Input.SeguroResidencial
{
    public class RemoverSeguroResidencialCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        bool ICommand.Valid() => true;
    }
}
