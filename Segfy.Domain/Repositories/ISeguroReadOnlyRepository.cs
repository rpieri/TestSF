using Segfy.Domain.Queries;
using System.Collections.Generic;

namespace Segfy.Domain.Repositories
{
    public interface ISeguroReadOnlyRepository
    {
        IEnumerable<SeguroQueryResult> Get(string filtroPlaca);
        SeguroQueryResult Get(int id);
    }
}
