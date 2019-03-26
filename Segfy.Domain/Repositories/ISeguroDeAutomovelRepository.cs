using Segfy.Domain.Entities;
using System.Collections.Generic;

namespace Segfy.Domain.Repositories
{
    public interface ISeguroDeAutomovelRepository
    {
        void Save(SeguroDeAutomovel seguro);
        void Update(SeguroDeAutomovel seguro);
        void Remove(int id);
        SeguroDeAutomovel Get(int id);
    }
}
