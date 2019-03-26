using Segfy.Domain.Entities;
using System.Collections.Generic;

namespace Segfy.Domain.Repositories
{
    public interface IClienteRepository
    {
        void Save(Cliente cliente);
        void Update(Cliente cliente);
        void Remove(int id);
        IEnumerable<Cliente> Get();
        Cliente Get(int id);
        bool VerificarSeDocumentoJaExiste(string documento);

    }
}
