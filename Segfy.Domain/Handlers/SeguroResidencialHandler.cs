using Flunt.Notifications;
using Segfy.Domain.Commands.Input.SeguroResidencial;
using Segfy.Domain.Commands.Output;
using Segfy.Domain.Commands.Output.SeguroResidenciais;
using Segfy.Domain.Entities;
using Segfy.Domain.Repositories;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Handlers
{
    public class SeguroResidencialHandler : Notifiable,
        ICommandHandler<CriarSeguraResidencialCommand>,
        ICommandHandler<AlterarSeguroResidencialCommand>,
        ICommandHandler<RemoverSeguroResidencialCommand>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ISeguroResidencialRepository seguroRepository;

        public SeguroResidencialHandler(IClienteRepository clienteRepository, ISeguroResidencialRepository seguroRepository)
        {
            this.clienteRepository = clienteRepository;
            this.seguroRepository = seguroRepository;
        }

        public ICommandResult Handler(CriarSeguraResidencialCommand command)
        {
            var cliente = clienteRepository.Get(command.ClienteId);
            if(cliente == null)
            {
                AddNotification("Cliente", "Cliente não foi encontrado");
            }

            var endereco = new Endereco(command.Rua, command.Numero, command.Complemento, command.Cep, command.Bairro, command.Cidade, command.Estado, command.Pais);
            var seguro = new SeguroResidencial(cliente, endereco, command.Valor);
            AddNotifications(endereco.Notifications);
            AddNotifications(seguro.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", "Notifications");
            }

            seguroRepository.Save(seguro);
            return new SeguroResidencialCommandResult(true, "Seguro residencial criado com sucesso", seguro);
        }

        public ICommandResult Handler(AlterarSeguroResidencialCommand command)
        {
            var cliente = clienteRepository.Get(command.ClienteId);
            var seguro = seguroRepository.Get(command.Id);
            var endereco = new Endereco(command.Rua, command.Numero, command.Complemento, command.Cep, command.Bairro, command.Cidade, command.Estado, command.Pais);

            seguro.Alterar(endereco, command.Valor);
            AddNotifications(endereco.Notifications);
            AddNotifications(seguro.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", "Notifications");
            }

            seguroRepository.Update(seguro);
            return new SeguroResidencialCommandResult(true, "Seguro residencial alterado com sucesso", seguro);
        }

        public ICommandResult Handler(RemoverSeguroResidencialCommand command)
        {
            seguroRepository.Remove(command.Id);
            return new CommandResult(true, "Seguro de vida removido com sucesso", null);
        }
    }
}
