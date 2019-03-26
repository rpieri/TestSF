using Segfy.Domain.Entities;
using SegFy.Shared.Commands;

namespace Segfy.Domain.Commands.Output.SeguroDeVidas
{
    public class SeguroDeVidaCommandResult : ICommandResult
    {
        public SeguroDeVidaCommandResult(bool success, string message, SeguroDeVida seguro)
        {
            Success = success;
            Message = message;
            Data = new { seguro.Id, idCliente = seguro.Cliente.Id, seguro.CPF };
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
