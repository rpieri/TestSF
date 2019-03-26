using Flunt.Notifications;
using Segfy.Domain.Commands.Input.SeguroAutomovel;
using Segfy.Domain.Commands.Output;
using Segfy.Domain.Commands.Output.SeguroAutomovels;
using Segfy.Domain.Entities;
using Segfy.Domain.Repositories;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Handlers
{
    public class SeguroDeAutomovelHandler : Notifiable,
        ICommandHandler<CriarSeguroDeAutomovelCommand>,
        ICommandHandler<AlterarSeguroDeAutomovelCommand>,
        ICommandHandler<RemoverSeguroDeAutomovelCommand>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ISeguroDeAutomovelRepository seguroRepository;

        public SeguroDeAutomovelHandler(IClienteRepository clienteRepository, ISeguroDeAutomovelRepository seguroRepository)
        {
            this.clienteRepository = clienteRepository;
            this.seguroRepository = seguroRepository;
        }

        public ICommandResult Handler(CriarSeguroDeAutomovelCommand command)
        {
            var cliente = clienteRepository.Get(command.ClienteId);
            if(cliente == null)
            {
                AddNotification("Cliente", "Cliente não foi encontrado");
            }

            var seguro = new SeguroDeAutomovel(cliente, command.Placa, command.Valor);
            AddNotifications(seguro.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", "Notifications");
            }

            seguroRepository.Save(seguro);
            return new SeguroAutomovelCommandResult(true, "Seguro de automovel criado com sucesso", seguro);
        }

        public ICommandResult Handler(AlterarSeguroDeAutomovelCommand command)
        {
            var cliente = clienteRepository.Get(command.ClienteId);
            var seguro = seguroRepository.Get(command.Id);

            seguro.Alterar(command.Placa, command.Valor);
            AddNotifications(seguro.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", "Notifications");
            }

            seguroRepository.Update(seguro);
            return new SeguroAutomovelCommandResult(true, "Seguro de vida alterado com sucesso", seguro);
        }

        public ICommandResult Handler(RemoverSeguroDeAutomovelCommand command)
        {
            seguroRepository.Remove(command.Id);
            return new CommandResult(true, "Seguro de vida removido com sucesso", null);
        }
    }
}
