using Segfy.Domain.Entities;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Output.SeguroAutomovels
{
    public class SeguroAutomovelCommandResult : ICommandResult
    {
        public SeguroAutomovelCommandResult(bool success, string message, SeguroDeAutomovel seguro)
        {
            Success = success;
            Message = message;
            Data = new { seguro.Id, idCliente = seguro.Cliente.Id, seguro.Placa };
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
