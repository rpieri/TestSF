using Segfy.Domain.Entities;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Output.SeguroResidenciais
{
    class SeguroResidencialCommandResult : ICommandResult
    {
        public SeguroResidencialCommandResult(bool success, string message, SeguroResidencial seguro)
        {
            Success = success;
            Message = message;
            Data = new { seguro.Id, IdCliente = seguro.Cliente.Id, IdEndereco = seguro.EnderecoDeRisco.Id};
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
