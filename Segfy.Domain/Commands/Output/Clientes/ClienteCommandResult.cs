using Segfy.Domain.Entities;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Output.Clientes
{
    public class ClienteCommandResult : ICommandResult
    {
        public ClienteCommandResult(bool success, string message, Cliente cliente)
        {
            Success = success;
            Message = message;
            Data = new { cliente.Id, cliente.Nome, cliente.Documento};
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
