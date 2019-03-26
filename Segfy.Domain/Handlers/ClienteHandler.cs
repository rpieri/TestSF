using Flunt.Notifications;
using Segfy.Domain.Commands.Input.Clientes;
using Segfy.Domain.Commands.Output;
using Segfy.Domain.Commands.Output.Clientes;
using Segfy.Domain.Entities;
using Segfy.Domain.Repositories;
using SegFy.Shared.Commands;
using System;

namespace Segfy.Domain.Handlers
{
    public class ClienteHandler : Notifiable,
        ICommandHandler<CriarClienteCommand>,
        ICommandHandler<AlterarClienteCommand>,
        ICommandHandler<RemoverClienteCommand>
    {
        private readonly IClienteRepository repository;

        public ClienteHandler(IClienteRepository repository)
        {
            this.repository = repository;
        }

        public ICommandResult Handler(CriarClienteCommand command)
        {
            if (repository.VerificarSeDocumentoJaExiste(command.Documento))
            {
                AddNotification("Documento", "Documento já está em uso");
            }

            var endereco = new Endereco(command.Rua, command.Numero, command.Complemento, 
                command.Cep, command.Bairro, command.Cidade, command.Estado, command.Pais);

            var cliente = new Cliente(command.Nome, command.Telefone, command.Email, command.Documento, endereco);

            AddNotifications(endereco.Notifications);
            AddNotifications(cliente.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", Notifications);
            }

            repository.Save(cliente);

            return new ClienteCommandResult(true, "Cliente cadastrado com sucesso", cliente);
        }

        public ICommandResult Handler(AlterarClienteCommand command)
        {
            var cliente = repository.Get(command.Id);
            if(cliente == null)
            {
                AddNotification("Cliente", "Cliente não foi encontrado");
            }

            cliente.Endereco.Alterar(command.Rua, command.Numero, command.Complemento,
                command.Cep, command.Bairro, command.Cidade, command.Estado, command.Pais);
            cliente.Alterar(command.Nome, command.Telefone, command.Email, command.Documento);

            AddNotifications(cliente.Endereco.Notifications);
            AddNotifications(cliente.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor corrija os campos abaixo", Notifications);
            }

            repository.Update(cliente);

            return new ClienteCommandResult(true, "Cliente alterado com sucesso", cliente);
        }

        public ICommandResult Handler(RemoverClienteCommand command)
        {
            repository.Remove(command.Id);
            return new CommandResult(true, "Cliente removido com sucesso", null);
        }
    }
}
