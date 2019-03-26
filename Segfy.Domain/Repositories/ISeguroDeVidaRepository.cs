using Segfy.Domain.Entities;

namespace Segfy.Domain.Repositories
{
    public interface ISeguroDeVidaRepository
    {
        void Save(SeguroDeVida seguro);
        void Update(SeguroDeVida seguro);
        void Remove(int id);
        SeguroDeVida Get(int id);
    }
}
