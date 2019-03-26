using Flunt.Notifications;
using Segfy.Domain.Commands.Input.SeguroDeVida;
using Segfy.Domain.Commands.Output;
using Segfy.Domain.Commands.Output.SeguroDeVidas;
using Segfy.Domain.Entities;
using Segfy.Domain.Repositories;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Handlers
{
    public class SeguroDeVidaHandler : Notifiable,
        ICommandHandler<CriarSeguroDeVidaCommand>,
        ICommandHandler<AlterarSeguroDeVidaCommand>,
        ICommandHandler<RemoverSeguroDeVidaCommand>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ISeguroDeVidaRepository seguroDeVidaRepository;

        public SeguroDeVidaHandler(IClienteRepository clienteRepository, ISeguroDeVidaRepository seguroDeVidaRepository)
        {
            this.clienteRepository = clienteRepository;
            this.seguroDeVidaRepository = seguroDeVidaRepository;
        }

        public ICommandResult Handler(CriarSeguroDeVidaCommand command)
        {
            var cliente = clienteRepository.Get(command.ClienteId);
            if(cliente == null)
            {
                AddNotification("Cliente", "Cliente não foi encontrado");
            }

            var seguro = new SeguroDeVida(cliente, command.CPF, command.Valor);
            AddNotifications(seguro.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", "Notifications");
            }

            seguroDeVidaRepository.Save(seguro);
            return new SeguroDeVidaCommandResult(true, "Seguro de vida criado com sucesso", seguro);
        }

        public ICommandResult Handler(AlterarSeguroDeVidaCommand command)
        {
            var cliente = clienteRepository.Get(command.ClienteId);
            var seguro = seguroDeVidaRepository.Get(command.Id);

            seguro.Alterar(command.CPF, command.Valor);
            AddNotifications(seguro.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", "Notifications");
            }

            seguroDeVidaRepository.Update(seguro);
            return new SeguroDeVidaCommandResult(true, "Seguro de vida alterado com sucesso", seguro);
        }

        public ICommandResult Handler(RemoverSeguroDeVidaCommand command)
        {
            seguroDeVidaRepository.Remove(command.Id);
            return new CommandResult(true, "Seguro de vida removido com sucesso", null);
        }
    }
}
