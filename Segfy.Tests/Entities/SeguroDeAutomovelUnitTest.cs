using Segfy.Tests.Builders;
using Xunit;

namespace Segfy.Tests.Entities
{
    public class SeguroDeAutomovelUnitTest
    {
        [Fact]
        public void SeguroDeAutomovelDeveEstarInvalido()
        {
            var seguro = new SeguroDeAutomovelBuilder()
                .ComCliente(null)
                .ComPlaca(string.Empty)
                .ComValor(0)
                .Builder();
            Assert.True(seguro.Invalid);
        }

        [Fact]
        public void SeguroDeAutomovelDeveEstarValido()
        {
            var seguro = new SeguroDeAutomovelBuilder().Builder();
            Assert.True(seguro.Invalid);
        }
    }
}
