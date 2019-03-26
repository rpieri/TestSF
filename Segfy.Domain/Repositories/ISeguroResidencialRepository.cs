using Segfy.Domain.Entities;

namespace Segfy.Domain.Repositories
{
    public interface ISeguroResidencialRepository
    {
        void Save(SeguroResidencial seguro);
        void Update(SeguroResidencial seguro);
        void Remove(int id);
        SeguroResidencial Get(int id);
    }
}
