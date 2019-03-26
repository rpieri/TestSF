using Segfy.Tests.Builders;
using Xunit;

namespace Segfy.Tests.Entities
{
    public class SeguroResidencialUnitTest
    {
        [Fact]
        public void SeguroResidenciaDeveEstarInvalido()
        {
            var seguro = new SeguroResidencialBuilder()
                .ComCliente(null)
                .ComEnderecoDeRisco(null)
                .ComValor(0)
                .Builder();
            Assert.True(seguro.Invalid);
        }

        [Fact]
        public void SeguroResidenciaDeveEstarValido()
        {
            var seguro = new SeguroResidencialBuilder().Builder();
            Assert.True(seguro.Invalid);
        }
    }
}
