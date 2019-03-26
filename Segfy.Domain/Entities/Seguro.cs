using Flunt.Validations;
using SegFy.Shared.Entities;

namespace Segfy.Domain.Entities
{
    public abstract class Seguro : Entity
    {
        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public decimal Valor { get; private set; }

        public Seguro(Cliente cliente, decimal valor)
        {
            ClienteId = cliente != null ? cliente.Id : 0;
            Cliente = cliente;
            Alterar(valor);
        }

        protected void Alterar(decimal valor)
        {
            Valor = valor;
            AddNotifications(new Contract()
                .IsGreaterThan(Valor, 0, "Valor", "O valor do seguro deve ser maior que 0"));
        }

        protected Seguro()
        {

        }        
    }
}
